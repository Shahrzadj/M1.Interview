using System.ComponentModel.DataAnnotations;

namespace Personnel.Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Operation completed successfully!")]
        Success = 0,

        [Display(Name = "An Error happened!")]
        ServerError = 1,

        [Display(Name = "Parameters are wrong!")]
        BadRequest = 2,

        [Display(Name = "Not Existed!")]
        NotFound = 3,

        [Display(Name = "List is empty!")]
        ListEmpty = 4,

        [Display(Name = "An Error happened in processing!")]
        LogicError = 5
    }
}
