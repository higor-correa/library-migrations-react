using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Enums
{
    public enum BookCategoryEnum : int
    {
        [Display(Name = "BookCategoryAction", ResourceType = typeof(EnumDescriptionResource))]
        Action,
        [Display(Name = "BookCategoryFiction", ResourceType = typeof(EnumDescriptionResource))]
        Fiction,
        [Display(Name = "BookCategorySyfy", ResourceType = typeof(EnumDescriptionResource))]
        Syfy
    }
}
