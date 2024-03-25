using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class DataTableAjaxPostModel
    {
        public string? CreatedBy { get; set; } // USerID
        public string? Remarks { get; set; } // USerID
        public int? Draw { get; set; }
        public List<Column>? Columns { get; set; }  // Columns - Search
        public List<Order>? Order { get; set; }
        public int? Start { get; set; } // 
        public int? Length { get; set; }  // PageSize (DropDown 10,20,30)
        public int? page { get; set; }  // Pagination Number (PageNo)
        public Search? Search { get; set; }  // Top Search
        public string? Zone_Id { get; set; }
        public string? Card_Id { get; set; }
    }

    public class Column
    {
        public string? Data { get; set; } // Column Name
        public string? Name { get; set; }
        public bool? Searchable { get; set; }
        public bool? Orderable { get; set; }
        public Search? Search { get; set; } // Column Search Value
    }

    public class Order
    {
        public int? Column { get; set; }
        public string? Dir { get; set; }
    }

    public class Search
    {
        public string? Value { get; set; } // Search Value
        public bool? Regex { get; set; }
    }

    public class Datatables_Param
    {
        public string? CreatedBy { get; set; }
        public string? SearchValue { get; set; }
        public string? PageNo { get; set; }
        public string? PageSize { get; set; }
        public string? SortColumn { get; set; }
        public string? SortDirection { get; set; }
    }
}
