using ObjCRuntime;

namespace Datadog.iOS.ObjC
{
	[Native]
	public enum DDBatchProcessingLevel : long
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	[Native]
	public enum DDBatchSize : long
	{
		Small = 0,
		Medium = 1,
		Large = 2
	}

	// removed internal DDCoreLoggerLevel

	[Native]
	public enum DDInjectEncoding : long
	{
		Multiple = 0,
		Single = 1
	}

	[Native]
	public enum DDLogEventInterface : long
	{
		WiFi = 0,
		WiredEthernet = 1,
		Cellular = 2,
		Loopback = 3,
		Other = 4
	}

	[Native]
	public enum DDLogEventRadioAccessTechnology : long
	{
		GPRS = 0,
		Edge = 1,
		WCDMA = 2,
		HSDPA = 3,
		HSUPA = 4,
		CDMA1x = 5,
		CDMAEVDORev0 = 6,
		CDMAEVDORevA = 7,
		CDMAEVDORevB = 8,
		EHRPD = 9,
		LTE = 10,
		Unknown = 11
	}

	[Native]
	public enum DDLogEventReachability : long
	{
		Yes = 0,
		Maybe = 1,
		No = 2
	}

	[Native]
	public enum DDLogEventStatus : long
	{
		Debug = 0,
		Info = 1,
		Notice = 2,
		Warn = 3,
		Error = 4,
		Critical = 5,
		Emergency = 6
	}

	[Native]
	public enum DDLogLevel : long
	{
		Debug = 0,
		Info = 1,
		Notice = 2,
		Warn = 3,
		Error = 4,
		Critical = 5
	}

	[Native]
	public enum DDRUMActionEventActionActionType : long
	{
		Custom = 0,
		Click = 1,
		Tap = 2,
		Scroll = 3,
		Swipe = 4,
		ApplicationStart = 5,
		Back = 6
	}

	[Native]
	public enum DDRUMActionEventActionFrustrationFrustrationType : long
	{
		RageClick = 0,
		DeadClick = 1,
		ErrorClick = 2,
		RageTap = 3,
		ErrorTap = 4
	}

	[Native]
	public enum DDRUMActionEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMActionEventDDActionNameSource : long
	{
		None = 0,
		CustomAttribute = 1,
		MaskPlaceholder = 2,
		StandardAttribute = 3,
		TextContent = 4,
		MaskDisallowed = 5,
		Blank = 6
	}

	[Native]
	public enum DDRUMActionEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMActionEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMActionEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2G = 1,
		EffectiveType2G = 2,
		EffectiveType3G = 3,
		EffectiveType4G = 4
	}

	[Native]
	public enum DDRUMActionEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMActionEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMActionEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMActionEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMActionEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMActionType : long
	{
		Tap = 0,
		Scroll = 1,
		Swipe = 2,
		Custom = 3
	}

	[Native]
	public enum DDRUMErrorEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMErrorEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMErrorEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMErrorEventErrorCSPDisposition : long
	{
		None = 0,
		Enforce = 1,
		Report = 2
	}

	[Native]
	public enum DDRUMErrorEventErrorCategory : long
	{
		None = 0,
		Anr = 1,
		AppHang = 2,
		Exception = 3,
		WatchdogTermination = 4,
		MemoryWarning = 5
	}

	[Native]
	public enum DDRUMErrorEventErrorCausesSource : long
	{
		Network = 0,
		Source = 1,
		Console = 2,
		Logger = 3,
		Agent = 4,
		Webview = 5,
		Custom = 6,
		Report = 7
	}

	[Native]
	public enum DDRUMErrorEventErrorHandling : long
	{
		None = 0,
		Handled = 1,
		Unhandled = 2
	}

	[Native]
	public enum DDRUMErrorEventErrorResourceProviderProviderType : long
	{
		None = 0,
		Ad = 1,
		Advertising = 2,
		Analytics = 3,
		CDN = 4,
		Content = 5,
		CustomerSuccess = 6,
		FirstParty = 7,
		Hosting = 8,
		Marketing = 9,
		Other = 10,
		Social = 11,
		TagManager = 12,
		Utility = 13,
		Video = 14
	}

	[Native]
	public enum DDRUMErrorEventErrorResourceRUMMethod : long
	{
		Post = 0,
		Get = 1,
		Head = 2,
		Put = 3,
		Delete = 4,
		Patch = 5,
		Trace = 6,
		Options = 7,
		Connect = 8
	}

	[Native]
	public enum DDRUMErrorEventErrorSource : long
	{
		Network = 0,
		Source = 1,
		Console = 2,
		Logger = 3,
		Agent = 4,
		Webview = 5,
		Custom = 6,
		Report = 7
	}

	[Native]
	public enum DDRUMErrorEventErrorSourceType : long
	{
		None = 0,
		Android = 1,
		Browser = 2,
		IOS = 3,
		ReactNative = 4,
		Flutter = 5,
		Roku = 6,
		NDK = 7,
		IOSIl2CPP = 8,
		NDKIl2CPP = 9
	}

	[Native]
	public enum DDRUMErrorEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2G = 1,
		EffectiveType2G = 2,
		EffectiveType3G = 3,
		EffectiveType4G = 4
	}

	[Native]
	public enum DDRUMErrorEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMErrorEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMErrorEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMErrorEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMErrorEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMErrorSource : long
	{
		Source = 0,
		Network = 1,
		Webview = 2,
		Console = 3,
		Custom = 4
	}

	[Native]
	public enum DDRUMLongTaskEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMLongTaskEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMLongTaskEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMLongTaskEventLongTaskEntryType : long
	{
		None = 0,
		LongTask = 1,
		LongAnimationFrame = 2
	}

	[Native]
	public enum DDRUMLongTaskEventLongTaskScriptsInvokerType : long
	{
		None = 0,
		UserCallback = 1,
		EventListener = 2,
		ResolvePromise = 3,
		RejectPromise = 4,
		ClassicScript = 5,
		ModuleScript = 6
	}

	[Native]
	public enum DDRUMLongTaskEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2G = 1,
		EffectiveType2G = 2,
		EffectiveType3G = 3,
		EffectiveType4G = 4
	}

	[Native]
	public enum DDRUMLongTaskEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMLongTaskEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMLongTaskEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMLongTaskEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMLongTaskEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMMethod : long
	{
		Post = 0,
		Get = 1,
		Head = 2,
		Put = 3,
		Delete = 4,
		Patch = 5,
		Connect = 6,
		Trace = 7,
		Options = 8
	}

	[Native]
	public enum DDRUMResourceEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMResourceEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMResourceEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMResourceEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2g = 1,
		EffectiveType2g = 2,
		EffectiveType3g = 3,
		EffectiveType4g = 4
	}

	[Native]
	public enum DDRUMResourceEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMResourceEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMResourceEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMResourceEventResourceDeliveryType : long
	{
		None = 0,
		Cache = 1,
		NavigationalPrefetch = 2,
		Other = 3
	}

	[Native]
	public enum DDRUMResourceEventResourceGraphqlOperationType : long
	{
		Query = 0,
		Mutation = 1,
		Subscription = 2
	}

	[Native]
	public enum DDRUMResourceEventResourceProviderProviderType : long
	{
		None = 0,
		Ad = 1,
		Advertising = 2,
		Analytics = 3,
		CDN = 4,
		Content = 5,
		CustomerSuccess = 6,
		FirstParty = 7,
		Hosting = 8,
		Marketing = 9,
		Other = 10,
		Social = 11,
		TagManager = 12,
		Utility = 13,
		Video = 14
	}

	[Native]
	public enum DDRUMResourceEventResourceRUMMethod : long
	{
		None = 0,
		Post = 1,
		Get = 2,
		Head = 3,
		Put = 4,
		Delete = 5,
		Patch = 6,
		Trace = 7,
		Options = 8,
		Connect = 9
	}

	[Native]
	public enum DDRUMResourceEventResourceRenderBlockingStatus : long
	{
		None = 0,
		Blocking = 1,
		NonBlocking = 2
	}

	[Native]
	public enum DDRUMResourceEventResourceResourceType : long
	{
		Document = 0,
		Xhr = 1,
		Beacon = 2,
		Fetch = 3,
		Css = 4,
		Js = 5,
		Image = 6,
		Font = 7,
		Media = 8,
		Other = 9,
		Native = 10
	}

	[Native]
	public enum DDRUMResourceEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMResourceEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMResourceType : long
	{
		Image = 0,
		Xhr = 1,
		Beacon = 2,
		Css = 3,
		Document = 4,
		Fetch = 5,
		Font = 6,
		Js = 7,
		Media = 8,
		Other = 9,
		Native = 10
	}

	[Native]
	public enum DDRUMViewEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMViewEventDDPageStatesState : long
	{
		Active = 0,
		Passive = 1,
		Hidden = 2,
		Frozen = 3,
		Terminated = 4
	}

	[Native]
	public enum DDRUMViewEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMViewEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMViewEventPrivacyReplayLevel : long
	{
		Allow = 0,
		Mask = 1,
		MaskUserInput = 2
	}

	[Native]
	public enum DDRUMViewEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2g = 1,
		EffectiveType2g = 2,
		EffectiveType3g = 3,
		EffectiveType4g = 4
	}

	[Native]
	public enum DDRUMViewEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMViewEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMViewEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMViewEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMViewEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMViewEventViewLoadingType : long
	{
		None = 0,
		InitialLoad = 1,
		RouteChange = 2,
		ActivityDisplay = 3,
		ActivityRedisplay = 4,
		FragmentDisplay = 5,
		FragmentRedisplay = 6,
		ViewControllerDisplay = 7,
		ViewControllerRedisplay = 8
	}

	[Native]
	public enum DDRUMVitalEventContainerSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Roku = 5,
		Unity = 6,
		KotlinMultiplatform = 7
	}

	[Native]
	public enum DDRUMVitalEventDDSessionPlan : long
	{
		None = 0,
		Plan1 = 1,
		Plan2 = 2
	}

	[Native]
	public enum DDRUMVitalEventDDSessionRUMSessionPrecondition : long
	{
		None = 0,
		UserAppLaunch = 1,
		InactivityTimeout = 2,
		MaxDuration = 3,
		BackgroundLaunch = 4,
		Prewarm = 5,
		FromNonInteractiveSession = 6,
		ExplicitStop = 7
	}

	[Native]
	public enum DDRUMVitalEventRUMConnectivityEffectiveType : long
	{
		None = 0,
		Slow2G = 1,
		EffectiveType2G = 2,
		EffectiveType3G = 3,
		EffectiveType4G = 4
	}

	[Native]
	public enum DDRUMVitalEventRUMConnectivityInterfaces : long
	{
		None = 0,
		Bluetooth = 1,
		Cellular = 2,
		Ethernet = 3,
		WiFi = 4,
		WiMax = 5,
		Mixed = 6,
		Other = 7,
		Unknown = 8,
		InterfacesNone = 9
	}

	[Native]
	public enum DDRUMVitalEventRUMConnectivityStatus : long
	{
		Connected = 0,
		NotConnected = 1,
		Maybe = 2
	}

	[Native]
	public enum DDRUMVitalEventRUMDeviceRUMDeviceType : long
	{
		Mobile = 0,
		Desktop = 1,
		Tablet = 2,
		TV = 3,
		GamingConsole = 4,
		Bot = 5,
		Other = 6
	}

	[Native]
	public enum DDRUMVitalEventSessionRUMSessionType : long
	{
		User = 0,
		Synthetics = 1,
		CITest = 2
	}

	[Native]
	public enum DDRUMVitalEventSource : long
	{
		None = 0,
		Android = 1,
		IOS = 2,
		Browser = 3,
		Flutter = 4,
		ReactNative = 5,
		Roku = 6,
		Unity = 7,
		KotlinMultiplatform = 8
	}

	[Native]
	public enum DDRUMVitalEventVitalVitalType : long
	{
		DDRUMVitalEventVitalVitalTypeDuration = 0
	}

	[Native]
	public enum DDRUMVitalsFrequency : long
	{
		Frequent = 0,
		Average = 1,
		Rare = 2,
		Never = 3
	}

	[Native]
	public enum DDSDKVerbosityLevel : long
	{
		None = 0,
		Debug = 1,
		Warn = 2,
		Error = 3,
		Critical = 4
	}

	[Native]
	public enum DDTelemetryConfigurationEventSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Unity = 5,
		KotlinMultiplatform = 6
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationSelectedTracingPropagators : long
	{
		None = 0,
		Datadog = 1,
		B3 = 2,
		B3Multi = 3,
		TraceContext = 4
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationSessionPersistence : long
	{
		None = 0,
		LocalStorage = 1,
		Cookie = 2
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationTraceContextInjection : long
	{
		None = 0,
		All = 1,
		Sampled = 2
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationTrackFeatureFlagsForEvents : long
	{
		None = 0,
		Vital = 1,
		Resource = 2,
		Action = 3,
		LongTask = 4
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationTrackingConsent : long
	{
		None = 0,
		Granted = 1,
		NotGranted = 2,
		Pending = 3
	}

	[Native]
	public enum DDTelemetryConfigurationEventTelemetryConfigurationViewTrackingStrategy : long
	{
		None = 0,
		ActivityViewTrackingStrategy = 1,
		FragmentViewTrackingStrategy = 2,
		MixedViewTrackingStrategy = 3,
		NavigationViewTrackingStrategy = 4
	}

	[Native]
	public enum DDTelemetryDebugEventSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Unity = 5,
		KotlinMultiplatform = 6
	}

	[Native]
	public enum DDTelemetryErrorEventSource : long
	{
		Android = 0,
		IOS = 1,
		Browser = 2,
		Flutter = 3,
		ReactNative = 4,
		Unity = 5,
		KotlinMultiplatform = 6
	}

	[Native]
	public enum DDTraceContextInjection : long
	{
		All = 0,
		Sampled = 1
	}

	[Native]
	public enum DDUploadFrequency : long
	{
		Frequent = 0,
		Average = 1,
		Rare = 2
	}
}
