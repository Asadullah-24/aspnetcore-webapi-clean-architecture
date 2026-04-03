using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Options
{
    public class TypicodeOptions
    {
        public const string SectionName = "Typicode";
        public string BaseUrl { get; set; } = null!;
    }

}
