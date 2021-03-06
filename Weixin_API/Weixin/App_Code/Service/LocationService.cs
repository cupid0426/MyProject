﻿using System.Collections.Generic;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.GoogleMap;
using Senparc.Weixin.MP.Helpers;

namespace Senparc.Weixin.MP.Sample.CommonService
{
    public class LocationService
    {
        public ResponseMessageNews GetResponseMessage(RequestMessageLocation requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);

            var markersList = new List<Markers>();
            markersList.Add(new Markers()
            {
                X = requestMessage.Location_X,
                Y = requestMessage.Location_Y,
                Color = "red",
                Label = "S",
                Size = MarkerSize.Default,
            });
            var mapSize = "480x600";
            var mapUrl = GoogleMapHelper.GetGoogleStaticMap(19 /*requestMessage.Scale*//*微信和GoogleMap的Scale不一致，这里建议使用固定值*/, markersList, size: mapSize);
            responseMessage.Articles.Add(new Article()
            {
                Description = requestMessage.Label,
                PicUrl = mapUrl,
                Title = "定位地点周边地图",
                Url = mapUrl
            });
            responseMessage.Articles.Add(new Article()
            {
                Title = "美天网络统一帐号管理系统",
                Description = "美天网络统一帐号管理系统",
                PicUrl = "http://www.xba.com.cn/NewPassLogin3/logo4.jpg",
                Url = "http://www.xba.com.cn"
            });
            responseMessage.Content = string.Format("您刚才发送了地理位置信息。Location_X：{0}，Location_Y：{1}，Scale：{2}，标签：{3}", requestMessage.Location_X, requestMessage.Location_Y, requestMessage.Scale, requestMessage.Label);
            return responseMessage;
        }
    }
}