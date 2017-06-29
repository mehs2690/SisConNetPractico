using System;

namespace MehsBugsWebApp.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AllowAnonymous : Attribute
    {
    }
}