using System.ComponentModel.DataAnnotations;

namespace Celebra.Core.Enums
{
    public enum CategoryType : byte
    {
        [Display(Name = "All")]
        All = 0,

        [Display(Name = "Family")]
        Family = 1,

        [Display(Name = "Friends")]
        Friends = 2,

        [Display(Name = "Work")]
        Work = 3,

        [Display(Name = "Other")]
        Other = 4,
    }
}
