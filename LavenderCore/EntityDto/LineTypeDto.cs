﻿

namespace Lavender.Core.EntityDto
{
    public class LineTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Worker_Wage_EachHour { get; set; }
        public decimal ProductionManager_Salary { get; set; }
    }
}
