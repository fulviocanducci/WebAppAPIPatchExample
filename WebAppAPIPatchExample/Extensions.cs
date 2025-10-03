using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace WebAppAPIPatchExample
{
    public static class Extensions
    {
        public static bool IsProblem(this ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.IsValid == false;
        }
    }
}
