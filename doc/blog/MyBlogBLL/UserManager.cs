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
        /// ����û�id�Ƿ��Ѵ���
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static bool LoginIdExists(string loginId)
        {
            return UserService.LoginIdExists(loginId);
        }
        /// <summary>
        /// ������û�
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User AddUser(User user)
        {
            return UserService.AddUser(user);
        }
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="loginId">��¼��</param>
        /// <param name="loginPwd">��¼����</param>
        /// <param name="validUser">����û�</param>
        /// <returns></returns>
        public static bool Login(string loginId, string loginPwd, out User validUser)
        {
            User user = UserService.GetUserByLoginId(loginId);
            if (user == null)
            {
                //�û��������� 
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
                //�������
                validUser = null;
                return false;
            }
        }
        /// <summary>
        /// ����id����û�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            return UserService.GetUserById(id);
        }
        /// <summary>
        /// ��������û����б�
        /// </summary>
        /// <returns></returns>
        public static IList<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }
        ///<summary>
        /// ע�����û�
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
