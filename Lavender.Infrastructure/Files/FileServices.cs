
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Lavender.Core.Interfaces.Files;


namespace Lavender.Infrastructure.Files
{
    public class FileServices : IFileServices
    {
        private readonly string _wwwroot;

        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            _wwwroot = webHostEnvironment.WebRootPath;
        }

        public async Task<string?> Upload(IFormFile? file)
        {
            if (file is null)
            {
                return null;
            }

            return await _upload(file);
        }
        public async Task<List<string>> Upload(List<IFormFile> files)
        {
            List<string?> paths = new();
            foreach (var file in files)
            {
                paths.Add(await Upload(file));
            }
            return paths!;
        }


        public async Task<string?> Modify(string? prop, IFormFile? file)
        {
            if (file is null)
                return prop;

            Delete(prop);
            return await Upload(file);
        }

        public async Task<List<string>> Modify(List<string> prop, List<IFormFile> files, List<string> deleted)
        {
            Delete(deleted!);
            deleted.ForEach(x => prop.Remove(x));
            prop.AddRange(await Upload(files));
            return prop;
        }

        public void Delete(string? path)
        {
            if (path == null || !path.StartsWith("Images"))
            {
                return;
            }
            var temp = Path.Combine(_wwwroot, path!);

            if (File.Exists(temp))
            {
                File.Delete(temp);
            }
        }
        public void Delete(List<string> path)
        {
            foreach (var p in path)
            {
                Delete(p);
            }
        }

        private string _subDir(string baseDir)
        {
            var dir = Path.Combine(baseDir, $"{DateTime.Now.Year}-{DateTime.Now.Month}");
            var fullDir = Path.Combine(_wwwroot, dir);
            if (!Directory.Exists(fullDir))
            {
                Directory.CreateDirectory(fullDir);
            }
            return dir;
        }

        private async Task<string> _upload(IFormFile file)
        {
            var dir = _subDir("Images");
            var path = Path.Combine(dir, Guid.NewGuid() + file.FileName);
            var st = new FileStream(Path.Combine(_wwwroot, path), FileMode.Create);
            await file.CopyToAsync(st);
            await st.DisposeAsync();
            st.Close();
            return path;
        }

    }
}
