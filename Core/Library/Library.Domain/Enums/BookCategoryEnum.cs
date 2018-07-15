using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Enums
{
    public enum BookCategoryEnum : int
    {
        [Display(Name = "BookCategoryAction")]
        Action = 1,
        [Display(Name = "BookCategoryFiction")]
        Fiction = 2,
        [Display(Name = "BookCategorySyfy")]
        Syfy = 3
    }
}
