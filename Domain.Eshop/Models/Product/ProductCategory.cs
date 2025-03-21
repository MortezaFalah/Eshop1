using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Eshop.Models.Common;

namespace Domain.Eshop.Models.Product;

public class ProductCategory : BaseEntity<int>

{

    [MaxLength(45, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Display(Name = "عنوان گروه")]
    public string Title { get; set; }

    [Display(Name = "عنوان والد")]
    public int? ParentId { get; set; }


    public bool IsDeleted { get; set; } = false;

    #region Relation
    [ForeignKey(nameof(ParentId))]
    public ProductCategory? category { get; set; }

    public List<ProductCategory>? ProductCategories { get; set; }


    public List<Product>? Products { get; set; }

    #endregion

}