using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Enums
{
    public enum BookCategoryEnum : int
    {
        [Display(Name = "BookCategoryAction")]
        Action,
        [Display(Name = "BookCategoryFiction")]
        Fiction,
        [Display(Name = "BookCategorySyfy")]
        Syfy
    }
}
