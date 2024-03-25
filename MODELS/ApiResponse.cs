using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MODELS
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
        public string? Status_Code { get; set; }
       
    }

    public class ApiResponseDT<T>: ApiResponse<T>
    {
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
    }

    public static class ApiResponseFactory
    {
        public static ApiResponse<T> Success<T>(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Message = M_Return_Status_Text.SUCCESS,
                Status = M_Return_Status_Code.TRUE,
                Status_Code = M_Return_Status_Code.OK
            };
        }
        public static ApiResponseDT<T> SuccessDT<T>(T data,string TR,string FR)
        {
            return new ApiResponseDT<T>
            {
                Data = data,
                Message = M_Return_Status_Text.SUCCESS,
                Status = M_Return_Status_Code.TRUE,
                Status_Code = M_Return_Status_Code.OK,
                RecordsTotal= TR,
                RecordsFiltered = FR,

            };
        }

        public static ApiResponseDT<object> ErrorDT()
        {
            return new ApiResponseDT<object>
            {
                Message = M_Return_Status_Text.NODATA,
                Status = M_Return_Status_Code.FALSE,
                Status_Code = M_Return_Status_Code.NODATA,
                RecordsTotal = "0",
                RecordsFiltered = "0",

            };
        }

        public static ApiResponse<object> Error()
        {
            return new ApiResponse<object>
            {

                Message = M_Return_Status_Text.NODATA,
                Status = M_Return_Status_Code.FALSE,
                Status_Code = M_Return_Status_Code.NODATA,
              
            };
        }

        public static ApiResponse<object> Invalid_Json()
        {
            return new ApiResponse<object>
            {

                Message = M_Return_Status_Text.INVALID_JSON,
                Status = M_Return_Status_Code.FALSE,
                Status_Code = M_Return_Status_Code.INVALID_JSON
            };
        }
        public static bool AllListsNotEmpty(object obj)
        {
            try
            {
                bool result = false;
                // Use reflection to get all properties of type List<T>
                var listProperties = obj.GetType().GetProperties()
                    .Where(p => p.PropertyType.IsGenericType &&
                                p.PropertyType.GetGenericTypeDefinition() == typeof(List<>));

                // Check if all lists are not empty using LINQ
                return listProperties.All(property =>
                {
                    var list = (IEnumerable<object>)property.GetValue(obj)!;
                    result = list != null && list.Any();
                    return result;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }

}
