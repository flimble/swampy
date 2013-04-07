using System.Collections.Generic;

namespace Swampy.Admin.Web.Models.Operation
{
    public class EnvironmentReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        
        public string Description { get; set; }

        public IList<ConfigurationItemInputModel> ConfigurationItems { get; set; }
    }
}