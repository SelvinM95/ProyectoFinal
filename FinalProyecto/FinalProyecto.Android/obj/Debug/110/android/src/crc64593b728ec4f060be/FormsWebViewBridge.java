package crc64593b728ec4f060be;


public class FormsWebViewBridge
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_InvokeAction:(Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("Xam.Plugin.WebView.Droid.FormsWebViewBridge, Xam.Plugin.WebView.Droid", FormsWebViewBridge.class, __md_methods);
	}


	public FormsWebViewBridge ()
	{
		super ();
		if (getClass () == FormsWebViewBridge.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewBridge, Xam.Plugin.WebView.Droid", "", this, new java.lang.Object[] {  });
	}

	public FormsWebViewBridge (crc64593b728ec4f060be.FormsWebViewRenderer p0)
	{
		super ();
		if (getClass () == FormsWebViewBridge.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewBridge, Xam.Plugin.WebView.Droid", "Xam.Plugin.WebView.Droid.FormsWebViewRenderer, Xam.Plugin.WebView.Droid", this, new java.lang.Object[] { p0 });
	}

	@android.webkit.JavascriptInterface

	public void invokeAction (java.lang.String p0)
	{
		n_InvokeAction (p0);
	}

	private native void n_InvokeAction (java.lang.String p0);

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
