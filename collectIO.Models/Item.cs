using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace collectIO.Models
{
    public class Item
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The 'Name' field can't be empty")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath 
        {
            get 
            {
                return ImagePath ?? "/images/no-image.png";
            }
            set 
            {
                this.ImagePath = value;
            } 
        }
        public string ImagePath;
        public int CollectionId { get; set; }
        public DateTime CreationDate { get; set; }      
        public Collection ParentCollection { get; set; }
        public string OwnerId { get; set; }
        public List<Comment> ItemComments { get; set; }
        public bool optionBool1 { get; set; }
        public bool optionBool2 { get; set; }
        public bool optionBool3 { get; set; }
        public string optionString1 { get; set; }
        public string optionString2 { get; set; }
        public string optionString3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText3 { get; set; }
        public int optionNumber1 { get; set; }
        public int optionNumber2 { get; set; }
        public int optionNumber3 { get; set; }

        public DateTime optionDate1 
        {
            get
            {
                return OptionDate1 ?? DateTime.Now;
            }
            set
            {
                this.OptionDate1 = value;
            }
        }
        private DateTime? OptionDate1 = null;


        public DateTime optionDate2
        {
            get
            {
                return OptionDate2 ?? DateTime.Now;
            }
            set
            {
                this.OptionDate2 = value;
            }
        }
        private DateTime? OptionDate2 = null;

        public DateTime optionDate3
        {
            get
            {
                return OptionDate3 ?? DateTime.Now;
            }
            set
            {
                this.OptionDate3 = value;
            }
        }
        private DateTime? OptionDate3 = null;
        public Dictionary<object, object> GetOptionsValues(Item thisItem)
        {
            Dictionary<object, object> options = new Dictionary<object, object>();

            foreach (var item in thisItem.GetType().GetProperties())
            {
                if (item.Name.Contains("option"))
                {
                    options.Add(item.Name, item.GetValue(thisItem,null));
                }
            }

            return options;
        }
    }
}
