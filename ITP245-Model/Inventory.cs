using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITP245_Model
{

    public interface IItem
    { 
        int Id { get; }
    }

    public interface IEmail
    {  
       string Email { get; }
       string Contact { get; }
    }



    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category:IItem
    {
        public int Id => CategoryId;
        private sealed class CategoryMetaData
        {
            [Display(Name = "Type")]
            public string Name { get; set; }

        }
    }

    [MetadataType(typeof(ItemMetaData))]
    public partial class Item:IItem
    {
        
        public int Id => ItemId;
        public HttpPostedFileBase FileName { get; set; }

        private sealed class ItemMetaData
        {
            [Display(Name ="Title")]
            public string Name { get; set; }

            [Display(Name ="Quantity on Hand")]
            public int QuantityOnHand { get; set; }

            [Display(Name = "Retail Price")]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal RetailPrice { get; set; }

            [Display(Name = "Standard Cost")]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal StandardCost { get; set; }

        }
    }
    [MetadataType(typeof(PoItemMetaData))]
    public partial class PoItem:IItem
    {
        public int Id => PoItemId;
        private sealed class PoItemMetaData
        {
            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal Price { get; set; }

            [Display(Name ="Purchase Order Number")]
            public int PurchaseOrderNumber { get; set; }
        }
    }
    [MetadataType(typeof(PurchaseOrderMetaData))]
    public partial class PurchaseOrder:IItem
    {
        // this might not be right
        public int Id => PurchaseOrderNumber;
        private sealed class PurchaseOrderMetaData
        {
            [Display(Name="Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
            public System.DateTime PoDate { get; set; }

            [Display(Name ="PO Number")]
            public int PurchaseOrderNumber { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal Amount { get; set; }


        }
    }
    [MetadataType(typeof(ReceiptMetaData))]
    public partial class Receipt:IItem
    {
        public int Id => ReceiptId;
        private sealed class ReceiptMetaData
        {

            [Display(Name = "Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
            public int ReceiptDate { get; set; }


            [DisplayFormat(DataFormatString = "{0:C}")]

            public decimal Amount { get; set; }

        }
    }
    [MetadataType(typeof(SpoilageMetaData))]
    public partial class Spoilage:IItem
    {
        public int Id => SpoilageId;
        private sealed class SpoilageMetaData
        {
            [Display(Name ="Reason Type" )]
            public int ReasonType { get; set; }

            [Display(Name = "Date of Occurrence")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
            public System.DateTime SpoilageDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal Value { get; set; }

        }
    }



    [MetadataType(typeof(VendorMetaData))]
    public partial class Vendor:IItem,IEmail
    {
        public int Id => VendorId;
        private sealed class VendorMetaData
        {
            [Display(Name = "Vendor Name")]
            public string Name { get; set; }
        }
    }
}
