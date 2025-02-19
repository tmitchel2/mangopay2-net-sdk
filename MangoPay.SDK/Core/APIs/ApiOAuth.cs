﻿using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for OAuth.</summary>
    public class ApiOAuth : ApiBase
    {
        /// <summary>Instantiates new ApiOAuth object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiOAuth(MangoPayApi root) : base(root) { }

        /// <summary>Async gets the new token used for requests authentication.</summary>
        /// <returns>OAuth object with token information.</returns>
        public async Task<OAuthTokenDTO> CreateTokenAsync(CreateOAuthTokenPostDTO entity)
        {
            var endPoint = GetApiEndPoint(MethodKey.AuthenticationOAuth);

            var restTool = new RestTool(this.Root, false);
            var authHelper = new AuthenticationHelper(Root);

            restTool.AddRequestHttpHeader(Constants.HOST, (new Uri(Root.Config.BaseUrl)).Host);
            restTool.AddRequestHttpHeader(Constants.AUTHORIZATION,
                $"{Constants.BASIC} {authHelper.GetHttpHeaderBasicKey()}");
            restTool.AddRequestHttpHeader(Constants.CONTENT_TYPE, Constants.APPLICATION_X_WWW_FORM_URLENCODED);
            if (Root.Config.UKHeaderFlag)
            {
                restTool.AddRequestHttpHeader(Constants.TENANT_ID, "uk");
            }

            return await restTool.RequestAsync<OAuthTokenDTO, CreateOAuthTokenPostDTO>(endPoint, null, entity);
        }   
    }
}
