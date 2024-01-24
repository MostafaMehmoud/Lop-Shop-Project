
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lap_Shop_Project.Models;

public partial class TbItem
{
    [ValidateNever]
    public int ItemId { get; set; }
    [Required(ErrorMessage ="Please enter name item")]
    public string ItemName { get; set; } = null!;
    [Required(ErrorMessage = "Please enter the sales price")]
    [DataType(DataType.Currency)]
    [Range(50,1000000,ErrorMessage ="please enter the sales between range[50,1000000]")]
    public decimal SalesPrice { get; set; }
    [Required(ErrorMessage = "Please enter the purchase price")]
    [DataType(DataType.Currency)]
    [Range(50, 1000000, ErrorMessage = "please enter the sales between range[50,1000000]")]
    public decimal PurchasePrice { get; set; }
    [Required(ErrorMessage = "Please enter category")]
    public int CategoryId { get; set; }

    public string? ImageName { get; set; }
    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Description { get; set; }
    
    public string? Gpu { get; set; }
    
    public string? HardDisk { get; set; }
    [Required(ErrorMessage = "Please enter item type")]
    public int? ItemTypeId { get; set; }
    
    public string? Processor { get; set; }
    [Required(ErrorMessage = "Please enter the purchase RamSize")]
    [DataType(DataType.Currency)]
    [Range(1, 100, ErrorMessage = "please enter the RamSize between range[1,100]")]
    public int? RamSize { get; set; }
     [Required(ErrorMessage = "Please enter the Screen Reslution")]
    public string? ScreenReslution { get; set; }
    [Required(ErrorMessage = "Please enter the Screen Size")]
    public string? ScreenSize { get; set; }
    [Required(ErrorMessage = "Please enter the Weight")]
    public string? Weight { get; set; }
    [Required(ErrorMessage = "Please enter os")]
    public int? OsId { get; set; }
    [ValidateNever]
    public virtual TbCategory Category { get; set; } = null!;
    [ValidateNever]
    public virtual TbItemType? ItemType { get; set; }
    [ValidateNever]
    public virtual TbO? Os { get; set; }

    public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; } = new List<TbItemDiscount>();

    public virtual ICollection<TbItemImage> TbItemImages { get; set; } = new List<TbItemImage>();

    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; } = new List<TbPurchaseInvoiceItem>();

    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; } = new List<TbSalesInvoiceItem>();

    public virtual ICollection<TbCustomer> Customers { get; set; } = new List<TbCustomer>();
}
