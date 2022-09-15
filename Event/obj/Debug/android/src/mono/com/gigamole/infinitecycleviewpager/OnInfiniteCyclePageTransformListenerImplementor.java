package mono.com.gigamole.infinitecycleviewpager;


public class OnInfiniteCyclePageTransformListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.gigamole.infinitecycleviewpager.OnInfiniteCyclePageTransformListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPostTransform:(Landroid/view/View;F)V:GetOnPostTransform_Landroid_view_View_FHandler:Com.Gigamole.Infinitecycleviewpager.IOnInfiniteCyclePageTransformListenerInvoker, InfiniteCycleViewPager\n" +
			"n_onPreTransform:(Landroid/view/View;F)V:GetOnPreTransform_Landroid_view_View_FHandler:Com.Gigamole.Infinitecycleviewpager.IOnInfiniteCyclePageTransformListenerInvoker, InfiniteCycleViewPager\n" +
			"";
		mono.android.Runtime.register ("Com.Gigamole.Infinitecycleviewpager.IOnInfiniteCyclePageTransformListenerImplementor, InfiniteCycleViewPager", OnInfiniteCyclePageTransformListenerImplementor.class, __md_methods);
	}


	public OnInfiniteCyclePageTransformListenerImplementor ()
	{
		super ();
		if (getClass () == OnInfiniteCyclePageTransformListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Gigamole.Infinitecycleviewpager.IOnInfiniteCyclePageTransformListenerImplementor, InfiniteCycleViewPager", "", this, new java.lang.Object[] {  });
	}


	public void onPostTransform (android.view.View p0, float p1)
	{
		n_onPostTransform (p0, p1);
	}

	private native void n_onPostTransform (android.view.View p0, float p1);


	public void onPreTransform (android.view.View p0, float p1)
	{
		n_onPreTransform (p0, p1);
	}

	private native void n_onPreTransform (android.view.View p0, float p1);

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
