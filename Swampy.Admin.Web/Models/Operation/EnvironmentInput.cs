using System.Collections.Generic;

namespace Swampy.Admin.Web.Models.Operation
{
    public class EnvironmentInput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
    }

    public class EnvironmentOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        

    }
}