using System;
using com.shephertz.app42.paas.sdk.csharp.user;
using com.shephertz.app42.paas.sdk.csharp;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
namespace AssemblyCSharp
{ 
public class UserResponce : MonoBehaviour
{
        public InputField _inputLogin, _inputPassword, _inputEnailId;
        public InputField _inputLoginAut, _inputPasswordAut;
        String userName;
        String pwd ;
        String emailId= "gsj@gmail.com" ;


        UserService userService = App42API.BuildUserService();
     
       
         
       
        public void aut  ()
        {
            ServiceAPI api = new ServiceAPI("37be471516e78a3693e7ca3ad228a8d73d9a55a9667b50838d97edd3dd80ee99", "4d70deecc103dccd19a3ad383c0f2949dd99abafa6a60cf23b4be995263c415c");
            UserService userService = api.BuildUserService();
            userName = _inputLoginAut.text;
            pwd = _inputPasswordAut.text;
            userService.Authenticate(userName, pwd, new UnityCallBack());
           
        }
        public void SrtvrtWork ()
        {
            userName = _inputLogin.text;
            emailId = _inputEnailId.text;
            pwd = _inputPassword.text;
            ServiceAPI api = new ServiceAPI("37be471516e78a3693e7ca3ad228a8d73d9a55a9667b50838d97edd3dd80ee99", "4d70deecc103dccd19a3ad383c0f2949dd99abafa6a60cf23b4be995263c415c");
            UserService userService = api.BuildUserService();
            userService.CreateUser(userName, pwd, emailId, new UnityCallBack());
           
        }
        
            
        
        
        public class UnityCallBack : App42CallBack
        {
            public void OnSuccess(object response)
            {
                User user = (User)response;
                App42Log.Console("userName is " + user.GetUserName());
                App42Log.Console("sessionId is " + user.GetSessionId());
                Debug.Log("+++++++++");
            }
            public void OnException(Exception e)
            {
                App42Log.Console("Exception : " + e);
                Debug.Log("-------"+e);
            }
        }
}
}

