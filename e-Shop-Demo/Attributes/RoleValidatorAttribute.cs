using e_Shop_Demo.Enums;
using System;

namespace e_Shop_Demo.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleValidatorAttribute : Attribute
    {
        public Role Role { get; }
        public RoleValidatorAttribute(Role role)
        {
            Role = role;
        }
    }
}
