package md53073dd610f132b6ccd016f6269250093;


public class SplashActvity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FernandoRibeiro.Droid.SplashActvity, FernandoRibeiro.Android", SplashActvity.class, __md_methods);
	}


	public SplashActvity ()
	{
		super ();
		if (getClass () == SplashActvity.class)
			mono.android.TypeManager.Activate ("FernandoRibeiro.Droid.SplashActvity, FernandoRibeiro.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
