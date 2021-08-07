package crc64593b728ec4f060be;


public class FormsWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceivedHttpError:(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;Landroid/webkit/WebResourceResponse;)V:GetOnReceivedHttpError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceResponse_Handler\n" +
			"n_onReceivedError:(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;Landroid/webkit/WebResourceError;)V:GetOnReceivedError_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Landroid_webkit_WebResourceError_Handler\n" +
			"n_shouldInterceptRequest:(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;)Landroid/webkit/WebResourceResponse;:GetShouldInterceptRequest_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Handler\n" +
			"n_onPageStarted:(Landroid/webkit/WebView;Ljava/lang/String;Landroid/graphics/Bitmap;)V:GetOnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_Handler\n" +
			"n_onReceivedSslError:(Landroid/webkit/WebView;Landroid/webkit/SslErrorHandler;Landroid/net/http/SslError;)V:GetOnReceivedSslError_Landroid_webkit_WebView_Landroid_webkit_SslErrorHandler_Landroid_net_http_SslError_Handler\n" +
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("Xam.Plugin.WebView.Droid.FormsWebViewClient, Xam.Plugin.WebView.Droid", FormsWebViewClient.class, __md_methods);
	}


	public FormsWebViewClient ()
	{
		super ();
		if (getClass () == FormsWebViewClient.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewClient, Xam.Plugin.WebView.Droid", "", this, new java.lang.Object[] {  });
	}

	public FormsWebViewClient (crc64593b728ec4f060be.FormsWebViewRenderer p0)
	{
		super ();
		if (getClass () == FormsWebViewClient.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewClient, Xam.Plugin.WebView.Droid", "Xam.Plugin.WebView.Droid.FormsWebViewRenderer, Xam.Plugin.WebView.Droid", this, new java.lang.Object[] { p0 });
	}


	public void onReceivedHttpError (android.webkit.WebView p0, android.webkit.WebResourceRequest p1, android.webkit.WebResourceResponse p2)
	{
		n_onReceivedHttpError (p0, p1, p2);
	}

	private native void n_onReceivedHttpError (android.webkit.WebView p0, android.webkit.WebResourceRequest p1, android.webkit.WebResourceResponse p2);


	public void onReceivedError (android.webkit.WebView p0, android.webkit.WebResourceRequest p1, android.webkit.WebResourceError p2)
	{
		n_onReceivedError (p0, p1, p2);
	}

	private native void n_onReceivedError (android.webkit.WebView p0, android.webkit.WebResourceRequest p1, android.webkit.WebResourceError p2);


	public android.webkit.WebResourceResponse shouldInterceptRequest (android.webkit.WebView p0, android.webkit.WebResourceRequest p1)
	{
		return n_shouldInterceptRequest (p0, p1);
	}

	private native android.webkit.WebResourceResponse n_shouldInterceptRequest (android.webkit.WebView p0, android.webkit.WebResourceRequest p1);


	public void onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2)
	{
		n_onPageStarted (p0, p1, p2);
	}

	private native void n_onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2);


	public void onReceivedSslError (android.webkit.WebView p0, android.webkit.SslErrorHandler p1, android.net.http.SslError p2)
	{
		n_onReceivedSslError (p0, p1, p2);
	}

	private native void n_onReceivedSslError (android.webkit.WebView p0, android.webkit.SslErrorHandler p1, android.net.http.SslError p2);


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
