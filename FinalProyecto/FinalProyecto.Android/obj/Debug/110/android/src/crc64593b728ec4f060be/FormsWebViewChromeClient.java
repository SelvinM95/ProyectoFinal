package crc64593b728ec4f060be;


public class FormsWebViewChromeClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xam.Plugin.WebView.Droid.FormsWebViewChromeClient, Xam.Plugin.WebView.Droid", FormsWebViewChromeClient.class, __md_methods);
	}


	public FormsWebViewChromeClient ()
	{
		super ();
		if (getClass () == FormsWebViewChromeClient.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewChromeClient, Xam.Plugin.WebView.Droid", "", this, new java.lang.Object[] {  });
	}

	public FormsWebViewChromeClient (crc64593b728ec4f060be.FormsWebViewRenderer p0)
	{
		super ();
		if (getClass () == FormsWebViewChromeClient.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.FormsWebViewChromeClient, Xam.Plugin.WebView.Droid", "Xam.Plugin.WebView.Droid.FormsWebViewRenderer, Xam.Plugin.WebView.Droid", this, new java.lang.Object[] { p0 });
	}

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
