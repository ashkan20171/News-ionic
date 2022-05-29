using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewsApi.DataLayer.Entities.Common;

namespace NewsApi.DataLayer.Entities.NewsEntities
{
    public class NewsCategory : BaseEntity
    {
        #region properties

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "اولویت نمایش")]
        public int Order { get; set; }

        [Display(Name = "نام تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        #endregion

        #region relations

        public ICollection<News> AllNews { get; set; }

        #endregion
    }
}
