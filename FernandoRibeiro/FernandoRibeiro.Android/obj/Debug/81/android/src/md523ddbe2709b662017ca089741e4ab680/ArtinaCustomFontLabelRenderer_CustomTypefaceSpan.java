package md523ddbe2709b662017ca089741e4ab680;


public class ArtinaCustomFontLabelRenderer_CustomTypefaceSpan
	extends android.text.style.TypefaceSpan
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_updateDrawState:(Landroid/text/TextPaint;)V:GetUpdateDrawState_Landroid_text_TextPaint_Handler\n" +
			"n_updateMeasureState:(Landroid/text/TextPaint;)V:GetUpdateMeasureState_Landroid_text_TextPaint_Handler\n" +
			"";
		mono.android.Runtime.register ("UXDivers.Artina.Shared.ArtinaCustomFontLabelRenderer+CustomTypefaceSpan, UXDivers.Artina.Shared.Droid", ArtinaCustomFontLabelRenderer_CustomTypefaceSpan.class, __md_methods);
	}


	public ArtinaCustomFontLabelRenderer_CustomTypefaceSpan (android.os.Parcel p0)
	{
		super (p0);
		if (getClass () == ArtinaCustomFontLabelRenderer_CustomTypefaceSpan.class)
			mono.android.TypeManager.Activate ("UXDivers.Artina.Shared.ArtinaCustomFontLabelRenderer+CustomTypefaceSpan, UXDivers.Artina.Shared.Droid", "Android.OS.Parcel, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ArtinaCustomFontLabelRenderer_CustomTypefaceSpan (java.lang.String p0)
	{
		super (p0);
		if (getClass () == ArtinaCustomFontLabelRenderer_CustomTypefaceSpan.class)
			mono.android.TypeManager.Activate ("UXDivers.Artina.Shared.ArtinaCustomFontLabelRenderer+CustomTypefaceSpan, UXDivers.Artina.Shared.Droid", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void updateDrawState (android.text.TextPaint p0)
	{
		n_updateDrawState (p0);
	}

	private native void n_updateDrawState (android.text.TextPaint p0);


	public void updateMeasureState (android.text.TextPaint p0)
	{
		n_updateMeasureState (p0);
	}

	private native void n_updateMeasureState (android.text.TextPaint p0);

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
