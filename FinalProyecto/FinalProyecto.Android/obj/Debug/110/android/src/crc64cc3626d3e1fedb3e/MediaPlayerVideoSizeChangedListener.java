package crc64cc3626d3e1fedb3e;


public class MediaPlayerVideoSizeChangedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.media.MediaPlayer.OnVideoSizeChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onVideoSizeChanged:(Landroid/media/MediaPlayer;II)V:GetOnVideoSizeChanged_Landroid_media_MediaPlayer_IIHandler:Android.Media.MediaPlayer/IOnVideoSizeChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xam.Forms.VideoPlayer.Android.MediaPlayerVideoSizeChangedListener, Xam.Forms.VideoPlayer.Android", MediaPlayerVideoSizeChangedListener.class, __md_methods);
	}


	public MediaPlayerVideoSizeChangedListener ()
	{
		super ();
		if (getClass () == MediaPlayerVideoSizeChangedListener.class)
			mono.android.TypeManager.Activate ("Xam.Forms.VideoPlayer.Android.MediaPlayerVideoSizeChangedListener, Xam.Forms.VideoPlayer.Android", "", this, new java.lang.Object[] {  });
	}


	public void onVideoSizeChanged (android.media.MediaPlayer p0, int p1, int p2)
	{
		n_onVideoSizeChanged (p0, p1, p2);
	}

	private native void n_onVideoSizeChanged (android.media.MediaPlayer p0, int p1, int p2);

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
