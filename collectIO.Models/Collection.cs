using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace collectIO.Models
{
    public class Collection
    {
        public int id { get; set; }

        [Required (ErrorMessage = "The 'Name' field can't be empty")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public CollectionType? collectionType { get; set; }
        public string CollectionAuthorID { get; set; }
        public List<Item> Items { get; set; }
        public DateTime CreationDate { get; set; }
        
        public string optionBool1 { get; set; }
        public string optionBool2 { get; set; }
        public string optionBool3 { get; set; }
        public string optionString1 { get; set; }
        public string optionString2 { get; set; }
        public string optionString3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string optionText3 { get; set; }
        public string optionNumber1 { get; set; }
        public string optionNumber2 { get; set; }
        public string optionNumber3 { get; set; }
        public string optionDate1 { get; set; }
        public string optionDate2 { get; set; }
        public string optionDate3 { get; set; }

        public Dictionary<string, string> GetItemOptions(Collection thisColl)
        {
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (var item in thisColl.GetType().GetProperties())
            {
                if (item.Name.Contains("option"))
                {
                    if (item.GetValue(thisColl) != null)
                    {
                        options.Add(item.GetValue(thisColl,null).ToString(), item.Name);
                    }
                }
            }

            return options;
        }

    }
}