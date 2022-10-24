﻿using Abp.Authorization;
using BackgroundJobAndNotificationsDemo.Authorization.Roles;
using BackgroundJobAndNotificationsDemo.MultiTenancy;
using BackgroundJobAndNotificationsDemo.Users;

namespace BackgroundJobAndNotificationsDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
