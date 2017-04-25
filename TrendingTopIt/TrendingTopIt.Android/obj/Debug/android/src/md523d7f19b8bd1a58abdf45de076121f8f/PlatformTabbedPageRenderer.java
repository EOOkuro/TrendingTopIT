package md523d7f19b8bd1a58abdf45de076121f8f;


public class PlatformTabbedPageRenderer
	extends md5270abb39e60627f0f200893b490a1ade.TabbedPageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Messier16.Forms.Controls.Droid.PlatformTabbedPageRenderer, Messier16.Forms.Controls.Droid.PlatformTabbedPage, Version=0.4.0.0, Culture=neutral, PublicKeyToken=null", PlatformTabbedPageRenderer.class, __md_methods);
	}


	public PlatformTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == PlatformTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("Messier16.Forms.Controls.Droid.PlatformTabbedPageRenderer, Messier16.Forms.Controls.Droid.PlatformTabbedPage, Version=0.4.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PlatformTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == PlatformTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("Messier16.Forms.Controls.Droid.PlatformTabbedPageRenderer, Messier16.Forms.Controls.Droid.PlatformTabbedPage, Version=0.4.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public PlatformTabbedPageRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PlatformTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("Messier16.Forms.Controls.Droid.PlatformTabbedPageRenderer, Messier16.Forms.Controls.Droid.PlatformTabbedPage, Version=0.4.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
