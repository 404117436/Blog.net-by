using System;
using System.Collections.Generic;
using System.Text;
using MyBlogModels;
using MyBlogDAL;
namespace MyBlogBLL
{
    public static class UserManager
    {
        /// <summary>
        /// 检测用户id是否已存在
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static bool LoginIdExists(string loginId)
        {
            return UserService.LoginIdExists(loginId);
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User AddUser(User user)
        {
            return UserService.AddUser(user);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginId">登录名</param>
        /// <param name="loginPwd">登录密码</param>
        /// <param name="validUser">输出用户</param>
        /// <returns></returns>
        public static bool Login(string loginId, string loginPwd, out User validUser)
        {
            User user = UserService.GetUserByLoginId(loginId);
            if (user == null)
            {
                //用户名不存在 
                validUser = null;
                return false;
            }
            if (user.LoginPwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //密码错误
                validUser = null;
                return false;
            }
        }
        /// <summary>
        /// 根据id获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            return UserService.GetUserById(id);
        }
        /// <summary>
        /// 获得所有用户的列表
        /// </summary>
        /// <returns></returns>
        public static IList<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }
        ///<summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Register(User user)
        {
            if (LoginIdExists(user.LoginId))
            {
                return false;
            }
            else
            {
                AddUser(user);
                return true;
            }
        }
    }
}
