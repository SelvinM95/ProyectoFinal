package crc64593b728ec4f060be;


public class JavascriptValueCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.webkit.ValueCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceiveValue:(Ljava/lang/Object;)V:GetOnReceiveValue_Ljava_lang_Object_Handler:Android.Webkit.IValueCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xam.Plugin.WebView.Droid.JavascriptValueCallback, Xam.Plugin.WebView.Droid", JavascriptValueCallback.class, __md_methods);
	}


	public JavascriptValueCallback ()
	{
		super ();
		if (getClass () == JavascriptValueCallback.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.JavascriptValueCallback, Xam.Plugin.WebView.Droid", "", this, new java.lang.Object[] {  });
	}

	public JavascriptValueCallback (crc64593b728ec4f060be.FormsWebViewRenderer p0)
	{
		super ();
		if (getClass () == JavascriptValueCallback.class)
			mono.android.TypeManager.Activate ("Xam.Plugin.WebView.Droid.JavascriptValueCallback, Xam.Plugin.WebView.Droid", "Xam.Plugin.WebView.Droid.FormsWebViewRenderer, Xam.Plugin.WebView.Droid", this, new java.lang.Object[] { p0 });
	}


	public void onReceiveValue (java.lang.Object p0)
	{
		n_onReceiveValue (p0);
	}

	private native void n_onReceiveValue (java.lang.Object p0);

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
