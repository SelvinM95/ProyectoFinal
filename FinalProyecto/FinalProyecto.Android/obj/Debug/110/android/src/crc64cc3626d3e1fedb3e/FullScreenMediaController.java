package crc64cc3626d3e1fedb3e;


public class FullScreenMediaController
	extends android.widget.MediaController
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setAnchorView:(Landroid/view/View;)V:GetSetAnchorView_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("Xam.Forms.VideoPlayer.Android.FullScreenMediaController, Xam.Forms.VideoPlayer.Android", FullScreenMediaController.class, __md_methods);
	}


	public FullScreenMediaController (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FullScreenMediaController.class)
			mono.android.TypeManager.Activate ("Xam.Forms.VideoPlayer.Android.FullScreenMediaController, Xam.Forms.VideoPlayer.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FullScreenMediaController (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FullScreenMediaController.class)
			mono.android.TypeManager.Activate ("Xam.Forms.VideoPlayer.Android.FullScreenMediaController, Xam.Forms.VideoPlayer.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FullScreenMediaController (android.content.Context p0, boolean p1)
	{
		super (p0, p1);
		if (getClass () == FullScreenMediaController.class)
			mono.android.TypeManager.Activate ("Xam.Forms.VideoPlayer.Android.FullScreenMediaController, Xam.Forms.VideoPlayer.Android", "Android.Content.Context, Mono.Android:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void setAnchorView (android.view.View p0)
	{
		n_setAnchorView (p0);
	}

	private native void n_setAnchorView (android.view.View p0);

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
