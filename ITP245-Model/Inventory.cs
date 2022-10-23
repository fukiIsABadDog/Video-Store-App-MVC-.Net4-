using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITP245_Model
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        private sealed class CategoryMetaData
        {
            [Display(Name = "Type")]
            public string Name { get; set; }

        }
    }

    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        private sealed class ItemMetaData
        {
            [Display(Name ="Title")]
            public string Name { get; set; }

        }
    }
    [MetadataType(typeof(PoItemMetaData))]
    public partial class PoItem
    {
        private sealed class PoItemMetaData
        {

        }
    }
    [MetadataType(typeof(PurchaseOrderMetaData))]
    public partial class PurchaseOrder
    {
        private sealed class PurchaseOrderMetaData
        {
            [Display(Name="Date")]
            public System.DateTime PoDate { get; set; }

        }
    }
    [MetadataType(typeof(ReceiptMetaData))]
    public partial class Receipt
    {
        private sealed class ReceiptMetaData
        {

        }
    }
    [MetadataType(typeof(SpoilageMetaData))]
    public partial class Spoilage
    {
        private sealed class SpoilageMetaData
        {

        }
    }
    [MetadataType(typeof(VendorMetaData))]
    public partial class Vendor
    {
        private sealed class VendorMetaData
        {
            [Display(Name = "Vendor Name")]
            public string Name { get; set; }
        }
}
}
