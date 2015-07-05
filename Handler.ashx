<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.IO;
using System.Web;

public class Handler : IHttpHandler {

	public bool IsReusable {
		get {
			return true;
		}
	}
	
	public void ProcessRequest (HttpContext context) {
		// 设置响应设置
		context.Response.ContentType = "image/jpeg";
		context.Response.Cache.SetCacheability(HttpCacheability.Public);
		context.Response.BufferOutput = false;
		// 设置 Size 参数
		PhotoSize size;
		switch (context.Request.QueryString["Size"]) {
			case "S":
				size = PhotoSize.Small;
				break;
			case "M":
				size = PhotoSize.Medium;
				break;
			case "L":
				size = PhotoSize.Large;
				break;
			default:
				size = PhotoSize.Original;
				break;
		} 
		// 设置 PhotoID 参数
		Int32 id = -1;
		Stream stream = null;
		if (context.Request.QueryString["PhotoID"] != null && context.Request.QueryString["PhotoID"] != "") {
			id = Convert.ToInt32(context.Request.QueryString["PhotoID"]);
			stream = PhotoManager.GetPhoto(id, size);
		} else {
			id = Convert.ToInt32(context.Request.QueryString["AlbumID"]);
			stream = PhotoManager.GetFirstPhoto(id, size);
		}
		// 从数据库获取照片，如果未返回照片，将获取默认的“placeholder”照片
		if (stream == null) stream = PhotoManager.GetPhoto(size);
		// 将图像流写入响应流中
		const int buffersize = 1024 * 16;
		byte[] buffer = new byte[buffersize];
		int count = stream.Read(buffer, 0, buffersize);
		while (count > 0) {
			context.Response.OutputStream.Write(buffer, 0, count);
			count = stream.Read(buffer, 0, buffersize);
		}
	}

}