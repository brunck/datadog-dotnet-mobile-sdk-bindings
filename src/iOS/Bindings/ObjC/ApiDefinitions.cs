using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Datadog.iOS.ObjC
{
	// @interface DDB3HTTPHeadersWriter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDB3HTTPHeadersWriter")]
	[DisableDefaultCtor]
	interface DDB3HTTPHeadersWriter
	{
		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull traceHeaderFields;
		[Export ("traceHeaderFields", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> TraceHeaderFields { get; }

		// removed deprecated constructors that cause build errors

		// -(instancetype _Nonnull)initWithSamplingStrategy:(DDTraceSamplingStrategy * _Nonnull)samplingStrategy injectEncoding:(enum DDInjectEncoding)injectEncoding traceContextInjection:(enum DDTraceContextInjection)traceContextInjection __attribute__((objc_designated_initializer));
		[Export ("initWithSamplingStrategy:injectEncoding:traceContextInjection:")]
		[DesignatedInitializer]
		NativeHandle Constructor (DDTraceSamplingStrategy samplingStrategy, DDInjectEncoding injectEncoding, DDTraceContextInjection traceContextInjection);
	}

	// @interface DDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc15DDConfiguration")]
	[DisableDefaultCtor]
	interface DDConfiguration
	{
		// @property (copy, nonatomic) NSString * _Nonnull clientToken;
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull env;
		[Export ("env")]
		string Env { get; set; }

		// @property (nonatomic, strong) DDSite * _Nonnull site;
		[Export ("site", ArgumentSemantic.Strong)]
		DDSite Site { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; set; }

		// @property (nonatomic) enum DDBatchSize batchSize;
		[Export ("batchSize", ArgumentSemantic.Assign)]
		DDBatchSize BatchSize { get; set; }

		// @property (nonatomic) enum DDUploadFrequency uploadFrequency;
		[Export ("uploadFrequency", ArgumentSemantic.Assign)]
		DDUploadFrequency UploadFrequency { get; set; }

		// @property (nonatomic) enum DDBatchProcessingLevel batchProcessingLevel;
		[Export ("batchProcessingLevel", ArgumentSemantic.Assign)]
		DDBatchProcessingLevel BatchProcessingLevel { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable proxyConfiguration;
		[NullAllowed, Export ("proxyConfiguration", ArgumentSemantic.Copy)]
		NSDictionary ProxyConfiguration { get; set; }

		// -(void)setEncryption:(id<DDDataEncryption> _Nonnull)encryption;
		[Export ("setEncryption:")]
		void SetEncryption (IDDDataEncryption encryption);

		// -(void)setServerDateProvider:(id<DDServerDateProvider> _Nonnull)serverDateProvider;
		[Export ("setServerDateProvider:")]
		void SetServerDateProvider (IDDServerDateProvider serverDateProvider);

		// @property (nonatomic, strong) NSBundle * _Nonnull bundle;
		[Export ("bundle", ArgumentSemantic.Strong)]
		NSBundle Bundle { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull additionalConfiguration;
		[Export ("additionalConfiguration", ArgumentSemantic.Copy)]
		[Internal]
		NSDictionary<NSString, NSObject> AdditionalConfiguration { get; set; }

		// @property (nonatomic) BOOL backgroundTasksEnabled;
		[Export ("backgroundTasksEnabled")]
		bool BackgroundTasksEnabled { get; set; }

		// -(instancetype _Nonnull)initWithClientToken:(NSString * _Nonnull)clientToken env:(NSString * _Nonnull)env __attribute__((objc_designated_initializer));
		[Export ("initWithClientToken:env:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string clientToken, string env);
	}

	interface IDDDataEncryption {}
    
    // @protocol DDDataEncryption
    [Protocol (Name = "_TtP11DatadogObjc16DDDataEncryption_")]
	interface DDDataEncryption
	{
		// @required -(NSData * _Nullable)encryptWithData:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("encryptWithData:error:")]
		[return: NullAllowed]
		NSData Encrypt(NSData data, [NullAllowed] out NSError error);

		// @required -(NSData * _Nullable)decryptWithData:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("decryptWithData:error:")]
		[return: NullAllowed]
		NSData Decrypt(NSData data, [NullAllowed] out NSError error);
	}

	// @interface DDDatadog : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc9DDDatadog")]
	interface DDDatadog
	{
		// +(void)initializeWithConfiguration:(DDConfiguration * _Nonnull)configuration trackingConsent:(DDTrackingConsent * _Nonnull)trackingConsent;
		[Static]
		[Export ("initializeWithConfiguration:trackingConsent:")]
		void Initialize (DDConfiguration configuration, DDTrackingConsent trackingConsent);

		// +(enum DDSDKVerbosityLevel)verbosityLevel __attribute__((warn_unused_result("")));
		// +(void)setVerbosityLevel:(enum DDSDKVerbosityLevel)verbosityLevel;
		[Static]
		[Export ("verbosityLevel")]
		DDSDKVerbosityLevel VerbosityLevel { get; set; }

		// +(void)setUserInfoWithUserId:(NSString * _Nonnull)userId name:(NSString * _Nullable)name email:(NSString * _Nullable)email extraInfo:(NSDictionary<NSString *, id> * _Nonnull)extraInfo;
		[Static]
		[Export ("setUserInfoWithUserId:name:email:extraInfo:")]
		void SetUserInfo (string userId, [NullAllowed] string name, [NullAllowed] string email, NSDictionary<NSString, NSObject> extraInfo);

		// replacing the deprecated method with the above
		// only difference is the parameter name and the type is no longer nullable

		// +(void)addUserExtraInfo:(NSDictionary<NSString *,id> * _Nonnull)extraInfo;
		[Static]
		[Export ("addUserExtraInfo:")]
		void AddUserExtraInfo (NSDictionary<NSString, NSObject> extraInfo);

		// +(void)setTrackingConsentWithConsent:(DDTrackingConsent * _Nonnull)consent;
		[Static]
		[Export ("setTrackingConsentWithConsent:")]
		void SetTrackingConsent(DDTrackingConsent consent);

		// +(BOOL)isInitialized __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isInitialized")]
		bool IsInitialized { get; }

		// +(void)stopInstance;
		[Static]
		[Export ("stopInstance")]
		void StopInstance ();

		// +(void)clearAllData;
		[Static]
		[Export ("clearAllData")]
		void ClearAllData ();

		// FlushAndDeinitialize() removed due to "compiled for testing" preprocessor directive in the Swift code
	}

	// @protocol DDUITouchRUMActionsPredicate
	[Protocol (Name = "_TtP11DatadogObjc28DDUITouchRUMActionsPredicate_")]
	interface DDUITouchRUMActionsPredicate
	{
		// @required -(DDRUMAction * _Nullable)rumActionWithTargetView:(UIView * _Nonnull)targetView __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("rumActionWithTargetView:")]
		[return: NullAllowed]
		DDRUMAction RumAction (UIView targetView);
	}

	// @protocol DDUIKitRUMActionsPredicate <DDUITouchRUMActionsPredicate>
	[Protocol (Name = "_TtP11DatadogObjc26DDUIKitRUMActionsPredicate_")]
	interface DDUIKitRUMActionsPredicate : DDUITouchRUMActionsPredicate
	{
	}

#pragma warning disable CS0108
	// @interface DDDefaultUIKitRUMActionsPredicate : NSObject <DDUIKitRUMActionsPredicate>
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDDefaultUIKitRUMActionsPredicate")]
	interface DDDefaultUIKitRUMActionsPredicate : DDUIKitRUMActionsPredicate
	{
		// -(DDRUMAction * _Nullable)rumActionWithTargetView:(UIView * _Nonnull)targetView __attribute__((warn_unused_result("")));
		[Export ("rumActionWithTargetView:")]
		[return: NullAllowed]
		DDRUMAction RumAction (UIView targetView);
	}

	// @protocol DDUIKitRUMViewsPredicate
	[Protocol (Name = "_TtP11DatadogObjc24DDUIKitRUMViewsPredicate_")]
	interface DDUIKitRUMViewsPredicate
	{
		// @required -(DDRUMView * _Nullable)rumViewFor:(UIViewController * _Nonnull)viewController __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("rumViewFor:")]
		[return: NullAllowed]
		DDRUMView RumView (UIViewController viewController);
	}

	// @interface DDDefaultUIKitRUMViewsPredicate : NSObject <DDUIKitRUMViewsPredicate>
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDDefaultUIKitRUMViewsPredicate")]
	interface DDDefaultUIKitRUMViewsPredicate : DDUIKitRUMViewsPredicate
	{
		// -(DDRUMView * _Nullable)rumViewFor:(UIViewController * _Nonnull)viewController __attribute__((warn_unused_result("")));
		[Export ("rumViewFor:")]
		[return: NullAllowed]
		DDRUMView RumView (UIViewController viewController);
	}
#pragma warning restore CS0108

	// @interface DDHTTPHeadersWriter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc19DDHTTPHeadersWriter")]
	[DisableDefaultCtor]
	interface DDHTTPHeadersWriter
	{
		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull traceHeaderFields;
		[Export ("traceHeaderFields", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> TraceHeaderFields { get; }

		// removed deprecated constructors that cause build errors

		// -(instancetype _Nonnull)initWithSamplingStrategy:(DDTraceSamplingStrategy * _Nonnull)samplingStrategy traceContextInjection:(enum DDTraceContextInjection)traceContextInjection __attribute__((objc_designated_initializer));
		[Export ("initWithSamplingStrategy:traceContextInjection:")]
		[DesignatedInitializer]
		NativeHandle Constructor (DDTraceSamplingStrategy samplingStrategy, DDTraceContextInjection traceContextInjection);
	}

	// removed DDInternalLogger

	// @interface DDLogEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc10DDLogEvent")]
	[DisableDefaultCtor]
	interface DDLogEvent
	{
		// @property (readonly, copy, nonatomic) NSDate * _Nonnull date;
		[Export ("date", ArgumentSemantic.Copy)]
		NSDate Date { get; }

		// @property (readonly, nonatomic) enum DDLogEventStatus status;
		[Export ("status")]
		DDLogEventStatus Status { get; }

		// @property (copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; set; }

		// @property (readonly, nonatomic, strong) DDLogEventError * _Nullable error;
		[NullAllowed, Export ("error", ArgumentSemantic.Strong)]
		DDLogEventError Error { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull serviceName;
		[Export ("serviceName")]
		string ServiceName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull environment;
		[Export ("environment")]
		string Environment { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull loggerName;
		[Export ("loggerName")]
		string LoggerName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull loggerVersion;
		[Export ("loggerVersion")]
		string LoggerVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable threadName;
		[NullAllowed, Export ("threadName")]
		string ThreadName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull applicationVersion;
		[Export ("applicationVersion")]
		string ApplicationVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull applicationBuildNumber;
		[Export ("applicationBuildNumber")]
		string ApplicationBuildNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable variant;
		[NullAllowed, Export ("variant")]
		string Variant { get; }

		// @property (readonly, nonatomic, strong) DDLogEventDd * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDLogEventDd Dd { get; }

		// @property (readonly, nonatomic, strong) DDLogEventOperatingSystem * _Nonnull os;
		[Export ("os", ArgumentSemantic.Strong)]
		DDLogEventOperatingSystem Os { get; }

		// @property (readonly, nonatomic, strong) DDLogEventUserInfo * _Nonnull userInfo;
		[Export ("userInfo", ArgumentSemantic.Strong)]
		DDLogEventUserInfo UserInfo { get; }

		// @property (readonly, nonatomic, strong) DDLogEventNetworkConnectionInfo * _Nullable networkConnectionInfo;
		[NullAllowed, Export ("networkConnectionInfo", ArgumentSemantic.Strong)]
		DDLogEventNetworkConnectionInfo NetworkConnectionInfo { get; }

		// @property (readonly, nonatomic, strong) DDLogEventCarrierInfo * _Nullable mobileCarrierInfo;
		[NullAllowed, Export ("mobileCarrierInfo", ArgumentSemantic.Strong)]
		DDLogEventCarrierInfo MobileCarrierInfo { get; }

		// @property (readonly, nonatomic, strong) DDLogEventAttributes * _Nonnull attributes;
		[Export ("attributes", ArgumentSemantic.Strong)]
		DDLogEventAttributes Attributes { get; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable tags;
		[NullAllowed, Export ("tags", ArgumentSemantic.Copy)]
		string[] Tags { get; set; }
	}

	// @interface DDLogEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDLogEventAttributes")]
	[DisableDefaultCtor]
	interface DDLogEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull userAttributes;
		[Export ("userAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserAttributes { get; set; }
	}

	// @interface DDLogEventBinaryImage : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDLogEventBinaryImage")]
	[DisableDefaultCtor]
	interface DDLogEventBinaryImage
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable arch;
		[NullAllowed, Export ("arch")]
		string Arch { get; }

		// @property (readonly, nonatomic) BOOL isSystem;
		[Export ("isSystem")]
		bool IsSystem { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable loadAddress;
		[NullAllowed, Export ("loadAddress")]
		string LoadAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable maxAddress;
		[NullAllowed, Export ("maxAddress")]
		string MaxAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull uuid;
		[Export ("uuid")]
		string Uuid { get; }
	}

	// @interface DDLogEventCarrierInfo : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDLogEventCarrierInfo")]
	[DisableDefaultCtor]
	interface DDLogEventCarrierInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierISOCountryCode;
		[NullAllowed, Export ("carrierISOCountryCode")]
		string CarrierISOCountryCode { get; }

		// @property (readonly, nonatomic) BOOL carrierAllowsVOIP;
		[Export ("carrierAllowsVOIP")]
		bool CarrierAllowsVOIP { get; }

		// @property (readonly, nonatomic) enum DDLogEventRadioAccessTechnology radioAccessTechnology;
		[Export ("radioAccessTechnology")]
		DDLogEventRadioAccessTechnology RadioAccessTechnology { get; }
	}

	// @interface DDLogEventDd : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc12DDLogEventDd")]
	[DisableDefaultCtor]
	interface DDLogEventDd
	{
		// @property (readonly, nonatomic, strong) DDLogEventDeviceInfo * _Nonnull device;
		[Export ("device", ArgumentSemantic.Strong)]
		DDLogEventDeviceInfo Device { get; }
	}

	// @interface DDLogEventDeviceInfo : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDLogEventDeviceInfo")]
	[DisableDefaultCtor]
	interface DDLogEventDeviceInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull brand;
		[Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull model;
		[Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull architecture;
		[Export ("architecture")]
		string Architecture { get; }
	}

	// @interface DDLogEventError : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc15DDLogEventError")]
	[DisableDefaultCtor]
	interface DDLogEventError
	{
		// @property (copy, nonatomic) NSString * _Nullable kind;
		[NullAllowed, Export ("kind")]
		string Kind { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable stack;
		[NullAllowed, Export ("stack")]
		string Stack { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull sourceType;
		[Export ("sourceType")]
		string SourceType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export ("fingerprint")]
		string Fingerprint { get; set; }

		// @property (copy, nonatomic) NSArray<DDLogEventBinaryImage *> * _Nullable binaryImages;
		[NullAllowed, Export ("binaryImages", ArgumentSemantic.Copy)]
		DDLogEventBinaryImage[] BinaryImages { get; set; }
	}

	// @interface DDLogEventNetworkConnectionInfo : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDLogEventNetworkConnectionInfo")]
	[DisableDefaultCtor]
	interface DDLogEventNetworkConnectionInfo
	{
		// @property (readonly, nonatomic) enum DDLogEventReachability reachability;
		[Export ("reachability")]
		DDLogEventReachability Reachability { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable availableInterfaces;
		[NullAllowed, Export ("availableInterfaces", ArgumentSemantic.Copy)]
		NSNumber[] AvailableInterfaces { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable supportsIPv4;
		[NullAllowed, Export ("supportsIPv4", ArgumentSemantic.Strong)]
		NSNumber SupportsIPv4 { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable supportsIPv6;
		[NullAllowed, Export ("supportsIPv6", ArgumentSemantic.Strong)]
		NSNumber SupportsIPv6 { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isExpensive;
		[NullAllowed, Export ("isExpensive", ArgumentSemantic.Strong)]
		NSNumber IsExpensive { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isConstrained;
		[NullAllowed, Export ("isConstrained", ArgumentSemantic.Strong)]
		NSNumber IsConstrained { get; }
	}

	// @interface DDLogEventOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDLogEventOperatingSystem")]
	[DisableDefaultCtor]
	interface DDLogEventOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }
	}

	// @interface DDLogEventUserInfo : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc18DDLogEventUserInfo")]
	[DisableDefaultCtor]
	interface DDLogEventUserInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull extraInfo;
		[Export ("extraInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ExtraInfo { get; set; }
	}

	// @interface DDLogger : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc8DDLogger")]
	[DisableDefaultCtor]
	interface DDLogger
	{
		// -(void)debug:(NSString * _Nonnull)message;
		[Export ("debug:")]
		void Debug (string message);

		// -(void)debug:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("debug:attributes:")]
		void Debug (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)debug:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("debug:error:attributes:")]
		void Debug (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)info:(NSString * _Nonnull)message;
		[Export ("info:")]
		void Info (string message);

		// -(void)info:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("info:attributes:")]
		void Info (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)info:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("info:error:attributes:")]
		void Info (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)notice:(NSString * _Nonnull)message;
		[Export ("notice:")]
		void Notice (string message);

		// -(void)notice:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("notice:attributes:")]
		void Notice (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)notice:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("notice:error:attributes:")]
		void Notice (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)warn:(NSString * _Nonnull)message;
		[Export ("warn:")]
		void Warn (string message);

		// -(void)warn:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("warn:attributes:")]
		void Warn (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)warn:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("warn:error:attributes:")]
		void Warn (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)error:(NSString * _Nonnull)message;
		[Export ("error:")]
		void Error (string message);

		// -(void)error:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("error:attributes:")]
		void Error (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)error:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("error:error:attributes:")]
		void Error (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)critical:(NSString * _Nonnull)message;
		[Export ("critical:")]
		void Critical (string message);

		// -(void)critical:(NSString * _Nonnull)message attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("critical:attributes:")]
		void Critical (string message, NSDictionary<NSString, NSObject> attributes);

		// -(void)critical:(NSString * _Nonnull)message error:(NSError * _Nonnull)error attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("critical:error:attributes:")]
		void Critical (string message, NSError error, NSDictionary<NSString, NSObject> attributes);

		// -(void)addAttributeForKey:(NSString * _Nonnull)key value:(id _Nonnull)value;
		[Export ("addAttributeForKey:value:")]
		void AddAttribute (string key, NSObject value);

		// -(void)removeAttributeForKey:(NSString * _Nonnull)key;
		[Export ("removeAttributeForKey:")]
		void RemoveAttribute (string key);

		// -(void)addTagWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value;
		[Export ("addTagWithKey:value:")]
		void AddTag (string key, string value);

		// -(void)removeTagWithKey:(NSString * _Nonnull)key;
		[Export ("removeTagWithKey:")]
		void RemoveTag (string key);

		// -(void)addWithTag:(NSString * _Nonnull)tag;
		[Export ("addWithTag:")]
		void Add (string tag);

		// -(void)removeWithTag:(NSString * _Nonnull)tag;
		[Export ("removeWithTag:")]
		void Remove (string tag);

		// +(DDLogger * _Nonnull)createWith:(DDLoggerConfiguration * _Nonnull)configuration __attribute__((warn_unused_result("")));
		[Static]
		[Export ("createWith:")]
		DDLogger Create (DDLoggerConfiguration configuration);
	}

	// @interface DDLoggerConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDLoggerConfiguration")]
	[DisableDefaultCtor]
	interface DDLoggerConfiguration
	{
		// @property (copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (nonatomic) BOOL networkInfoEnabled;
		[Export ("networkInfoEnabled")]
		bool NetworkInfoEnabled { get; set; }

		// @property (nonatomic) BOOL bundleWithRumEnabled;
		[Export ("bundleWithRumEnabled")]
		bool BundleWithRumEnabled { get; set; }

		// @property (nonatomic) BOOL bundleWithTraceEnabled;
		[Export ("bundleWithTraceEnabled")]
		bool BundleWithTraceEnabled { get; set; }

		// @property (nonatomic) float remoteSampleRate;
		[Export ("remoteSampleRate")]
		float RemoteSampleRate { get; set; }

		// @property (nonatomic) BOOL printLogsToConsole;
		[Export ("printLogsToConsole")]
		bool PrintLogsToConsole { get; set; }

		// @property (nonatomic) enum DDLogLevel remoteLogThreshold;
		[Export ("remoteLogThreshold", ArgumentSemantic.Assign)]
		DDLogLevel RemoteLogThreshold { get; set; }

		// -(instancetype _Nonnull)initWithService:(NSString * _Nullable)service name:(NSString * _Nullable)name networkInfoEnabled:(BOOL)networkInfoEnabled bundleWithRumEnabled:(BOOL)bundleWithRumEnabled bundleWithTraceEnabled:(BOOL)bundleWithTraceEnabled remoteSampleRate:(float)remoteSampleRate remoteLogThreshold:(enum DDLogLevel)remoteLogThreshold printLogsToConsole:(BOOL)printLogsToConsole __attribute__((objc_designated_initializer));
		[Export ("initWithService:name:networkInfoEnabled:bundleWithRumEnabled:bundleWithTraceEnabled:remoteSampleRate:remoteLogThreshold:printLogsToConsole:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] string service, [NullAllowed] string name, bool networkInfoEnabled, bool bundleWithRumEnabled, bool bundleWithTraceEnabled, float remoteSampleRate, DDLogLevel remoteLogThreshold, bool printLogsToConsole);
	}

	// @interface DDLogs : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc6DDLogs")]
	interface DDLogs
	{
		// +(void)enableWith:(DDLogsConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("enableWith:")]
		void Enable (DDLogsConfiguration configuration);

		// +(void)addAttributeForKey:(NSString * _Nonnull)key value:(id _Nonnull)value;
		[Static]
		[Export ("addAttributeForKey:value:")]
		void AddAttribute (string key, NSObject value);

		// +(void)removeAttributeForKey:(NSString * _Nonnull)key;
		[Static]
		[Export ("removeAttributeForKey:")]
		void RemoveAttribute (string key);
	}

	// @interface DDLogsConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc19DDLogsConfiguration")]
	[DisableDefaultCtor]
	interface DDLogsConfiguration
	{
		// @property (copy, nonatomic) NSURL * _Nullable customEndpoint;
		[NullAllowed, Export ("customEndpoint", ArgumentSemantic.Copy)]
		NSUrl CustomEndpoint { get; set; }

		// -(instancetype _Nonnull)initWithCustomEndpoint:(NSURL * _Nullable)customEndpoint __attribute__((objc_designated_initializer));
		[Export ("initWithCustomEndpoint:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSUrl customEndpoint);

		// -(void)setEventMapper:(DDLogEvent * _Nullable (^ _Nonnull)(DDLogEvent * _Nonnull))mapper;
		[Export ("setEventMapper:")]
		void SetEventMapper (Func<DDLogEvent, DDLogEvent> mapper);
	}

	// remove deprecated class DDNSURLSessionDelegate

	// @interface DDOTelHTTPHeadersWriter : DDB3HTTPHeadersWriter
	[BaseType (typeof(DDB3HTTPHeadersWriter), Name = "_TtC11DatadogObjc23DDOTelHTTPHeadersWriter")]
	[Obsolete("Deprecated, renamed: DDB3HTTPHeadersWriter")]
	interface DDOTelHTTPHeadersWriter
	{
		// -(instancetype _Nonnull)initWithSampleRate:(float)sampleRate injectEncoding:(enum DDInjectEncoding)injectEncoding __attribute__((objc_designated_initializer)) __attribute__((deprecated("This will be removed in future versions of the SDK. Use `init(samplingStrategy: .custom(sampleRate:))` instead.", "DDB3HTTPHeadersWriter")));
		[Export ("initWithSampleRate:injectEncoding:")]
		[DesignatedInitializer]
		NativeHandle Constructor (float sampleRate, DDInjectEncoding injectEncoding);

		// -(instancetype _Nonnull)initWithSamplingStrategy:(DDTraceSamplingStrategy * _Nonnull)samplingStrategy injectEncoding:(enum DDInjectEncoding)injectEncoding traceContextInjection:(enum DDTraceContextInjection)traceContextInjection __attribute__((objc_designated_initializer));
		[Export ("initWithSamplingStrategy:injectEncoding:traceContextInjection:")]
		[DesignatedInitializer]
		NativeHandle Constructor (DDTraceSamplingStrategy samplingStrategy, DDInjectEncoding injectEncoding, DDTraceContextInjection traceContextInjection);
	}

	// @interface DDRUM : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc5DDRUM")]
	interface DDRUM
	{
		// +(void)enableWith:(DDRUMConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("enableWith:")]
		void Enable (DDRUMConfiguration configuration);
	}

	// @interface DDRUMAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc11DDRUMAction")]
	[DisableDefaultCtor]
	interface DDRUMAction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
		[Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithName:attributes:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string name, NSDictionary<NSString, NSObject> attributes);
	}

	// @interface DDRUMActionEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc16DDRUMActionEvent")]
	[DisableDefaultCtor]
	interface DDRUMActionEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMActionEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMActionEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMActionEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventAction * _Nonnull action;
		[Export("action", ArgumentSemantic.Strong)]
		DDRUMActionEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventApplication * _Nonnull application;
		[Export ("application", ArgumentSemantic.Strong)]
		DDRUMActionEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMActionEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMActionEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMOperatingSystem Os { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMActionEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventSource source;
		[Export ("source")]
		DDRUMActionEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMActionEventView View { get; }
	}

	// @interface DDRUMActionEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMActionEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMActionEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccountInfo { get; set; }
	}

	// @interface DDRUMActionEventAction : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMActionEventAction")]
	[DisableDefaultCtor]
	interface DDRUMActionEventAction
	{
		// @property (readonly, nonatomic, strong) DDRUMActionEventActionCrash * _Nullable crash;
		[NullAllowed, Export ("crash", ArgumentSemantic.Strong)]
		DDRUMActionEventActionCrash Crash { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventActionError * _Nullable error;
		[NullAllowed, Export ("error", ArgumentSemantic.Strong)]
		DDRUMActionEventActionError Error { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventActionFrustration * _Nullable frustration;
		[NullAllowed, Export ("frustration", ArgumentSemantic.Strong)]
		DDRUMActionEventActionFrustration Frustration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable loadingTime;
		[NullAllowed, Export ("loadingTime", ArgumentSemantic.Strong)]
		NSNumber LoadingTime { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventActionLongTask * _Nullable longTask;
		[NullAllowed, Export ("longTask", ArgumentSemantic.Strong)]
		DDRUMActionEventActionLongTask LongTask { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventActionResource * _Nullable resource;
		[NullAllowed, Export ("resource", ArgumentSemantic.Strong)]
		DDRUMActionEventActionResource Resource { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventActionTarget * _Nullable target;
		[NullAllowed, Export ("target", ArgumentSemantic.Strong)]
		DDRUMActionEventActionTarget Target { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventActionActionType type;
		[Export ("type")]
		DDRUMActionEventActionActionType Type { get; }
	}

	// @interface DDRUMActionEventActionCrash : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMActionEventActionCrash")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionCrash
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMActionEventActionError : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMActionEventActionError")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionError
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMActionEventActionFrustration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMActionEventActionFrustration")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionFrustration
	{
		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull type;
		[Export ("type", ArgumentSemantic.Copy)]
		NSNumber[] Type { get; }
	}

	// @interface DDRUMActionEventActionLongTask : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMActionEventActionLongTask")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionLongTask
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMActionEventActionResource : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMActionEventActionResource")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionResource
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMActionEventActionTarget : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDRUMActionEventActionTarget")]
	[DisableDefaultCtor]
	interface DDRUMActionEventActionTarget
	{
		// @property (copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; set; }
	}

	// @interface DDRUMActionEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMActionEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMActionEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMActionEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMActionEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMActionEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMActionEventContainerSource source;
		[Export ("source")]
		DDRUMActionEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMActionEventContainerView View { get; }
	}

	// @interface DDRUMActionEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMActionEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMActionEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMActionEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc18DDRUMActionEventDD")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDD
	{
		// @property (readonly, nonatomic, strong) DDRUMActionEventDDAction * _Nullable action;
		[NullAllowed, Export ("action", ArgumentSemantic.Strong)]
		DDRUMActionEventDDAction Action { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		DDRUMActionEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMActionEventDDSession Session { get; }
	}

	// @interface DDRUMActionEventDDAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMActionEventDDAction")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDDAction
	{
		// @property (nonatomic) enum DDRUMActionEventDDActionNameSource nameSource;
		[Export ("nameSource", ArgumentSemantic.Assign)]
		DDRUMActionEventDDActionNameSource NameSource { get; set; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventDDActionPosition * _Nullable position;
		[NullAllowed, Export ("position", ArgumentSemantic.Strong)]
		DDRUMActionEventDDActionPosition Position { get; }

		// @property (readonly, nonatomic, strong) DDRUMActionEventDDActionTarget * _Nullable target;
		[NullAllowed, Export ("target", ArgumentSemantic.Strong)]
		DDRUMActionEventDDActionTarget Target { get; }
	}

	// @interface DDRUMActionEventDDActionPosition : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMActionEventDDActionPosition")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDDActionPosition
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull x;
		[Export ("x", ArgumentSemantic.Strong)]
		NSNumber X { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull y;
		[Export ("y", ArgumentSemantic.Strong)]
		NSNumber Y { get; }
	}

	// @interface DDRUMActionEventDDActionTarget : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMActionEventDDActionTarget")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDDActionTarget
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable height;
		[NullAllowed, Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable selector;
		[NullAllowed, Export ("selector")]
		string CssSelector { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable width;
		[NullAllowed, Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMActionEventDDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMActionEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }
	}

	// @interface DDRUMActionEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMActionEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMActionEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMActionEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMActionEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMActionEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMActionEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMActionEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMActionEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMActionEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMActionEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMActionEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMActionEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMActionEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMActionEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMActionEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMActionEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMActionEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMActionEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMActionEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMActionEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc39DDRUMActionEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMActionEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMActionEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMActionEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMActionEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMActionEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMActionEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMActionEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMActionEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMActionEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMActionEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMActionEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMActionEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMActionEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMActionEventSession")]
	[DisableDefaultCtor]
	interface DDRUMActionEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMActionEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMActionEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMActionEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDRUMActionEventView")]
	[DisableDefaultCtor]
	interface DDRUMActionEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable inForeground;
		[NullAllowed, Export ("inForeground", ArgumentSemantic.Strong)]
		NSNumber InForeground { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export ("referrer")]
		string Referrer { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	interface IDDUIKitRUMViewsPredicate { }

	interface IDDUIKitRUMActionsPredicate { }

	// @interface DDRUMConfiguration : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc18DDRUMConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMConfiguration
	{
		// -(instancetype _Nonnull)initWithApplicationID:(NSString * _Nonnull)applicationID __attribute__((objc_designated_initializer));
		[Export("initWithApplicationID:")]
		[DesignatedInitializer]
		NativeHandle Constructor(string applicationId);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull applicationID;
		[Export("applicationID")]
		string ApplicationId { get; }

		// @property (nonatomic) float sessionSampleRate;
		[Export("sessionSampleRate")]
		float SessionSampleRate { get; set; }

		// @property (nonatomic) float telemetrySampleRate;
		[Export("telemetrySampleRate")]
		float TelemetrySampleRate { get; set; }

		// @property (nonatomic, strong) id<DDUIKitRUMViewsPredicate> _Nullable uiKitViewsPredicate;
		[NullAllowed, Export("uiKitViewsPredicate", ArgumentSemantic.Strong)]
		IDDUIKitRUMViewsPredicate UIKitViewsPredicate { get; set; }

		// @property (nonatomic, strong) id<DDUIKitRUMActionsPredicate> _Nullable uiKitActionsPredicate;
		[NullAllowed, Export("uiKitActionsPredicate", ArgumentSemantic.Strong)]
		IDDUIKitRUMActionsPredicate UIKitActionsPredicate { get; set; }

		// -(void)setURLSessionTracking:(DDRUMURLSessionTracking * _Nonnull)tracking;
		[Export("setURLSessionTracking:")]
		void SetURLSessionTracking(DDRUMURLSessionTracking tracking);

		// @property (nonatomic) BOOL trackFrustrations;
		[Export("trackFrustrations")]
		bool TrackFrustrations { get; set; }

		// @property (nonatomic) BOOL trackBackgroundEvents;
		[Export("trackBackgroundEvents")]
		bool TrackBackgroundEvents { get; set; }

		// @property (nonatomic) BOOL trackWatchdogTerminations;
		[Export("trackWatchdogTerminations")]
		bool TrackWatchdogTerminations { get; set; }

		// @property (nonatomic) NSTimeInterval longTaskThreshold;
		[Export("longTaskThreshold")]
		double LongTaskThreshold { get; set; }

		// @property (nonatomic) NSTimeInterval appHangThreshold;
		[Export("appHangThreshold")]
		double AppHangThreshold { get; set; }

		// @property (nonatomic) enum DDRUMVitalsFrequency vitalsUpdateFrequency;
		[Export("vitalsUpdateFrequency", ArgumentSemantic.Assign)]
		DDRUMVitalsFrequency VitalsUpdateFrequency { get; set; }

		// -(void)setViewEventMapper:(DDRUMViewEvent * _Nonnull (^ _Nonnull)(DDRUMViewEvent * _Nonnull))mapper;
		[Export("setViewEventMapper:")]
		void SetViewEventMapper(Func<DDRUMViewEvent, DDRUMViewEvent> mapper);

		// -(void)setResourceEventMapper:(DDRUMResourceEvent * _Nullable (^ _Nonnull)(DDRUMResourceEvent * _Nonnull))mapper;
		[Export("setResourceEventMapper:")]
		void SetResourceEventMapper(Func<DDRUMResourceEvent, DDRUMResourceEvent> mapper);

		// -(void)setActionEventMapper:(DDRUMActionEvent * _Nullable (^ _Nonnull)(DDRUMActionEvent * _Nonnull))mapper;
		[Export("setActionEventMapper:")]
		void SetActionEventMapper(Func<DDRUMActionEvent, DDRUMActionEvent> mapper);

		// -(void)setErrorEventMapper:(DDRUMErrorEvent * _Nullable (^ _Nonnull)(DDRUMErrorEvent * _Nonnull))mapper;
		[Export("setErrorEventMapper:")]
		void SetErrorEventMapper(Func<DDRUMErrorEvent, DDRUMErrorEvent> mapper);

		// -(void)setLongTaskEventMapper:(DDRUMLongTaskEvent * _Nullable (^ _Nonnull)(DDRUMLongTaskEvent * _Nonnull))mapper;
		[Export("setLongTaskEventMapper:")]
		void SetLongTaskEventMapper(Func<DDRUMLongTaskEvent, DDRUMLongTaskEvent> mapper);

		// @property (copy, nonatomic) void (^ _Nullable)(NSString * _Nonnull, BOOL) onSessionStart;
		[NullAllowed, Export("onSessionStart", ArgumentSemantic.Copy)]
		Action<NSString, bool> OnSessionStart { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable customEndpoint;
		[NullAllowed, Export("customEndpoint", ArgumentSemantic.Copy)]
		NSUrl CustomEndpoint { get; set; }

		// @property (nonatomic) BOOL trackAnonymousUser;
		[Export("trackAnonymousUser")]
		bool TrackAnonymousUser { get; set; }
	}

	// @interface DDRUMErrorEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc15DDRUMErrorEvent")]
	[DisableDefaultCtor]
	interface DDRUMErrorEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMErrorEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMErrorEventDD DD { get; }

		// @property (nonatomic, readonly, strong) DDRUMErrorEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMErrorEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventAction * _Nullable action;
		[NullAllowed, Export("action", ArgumentSemantic.Strong)]
		DDRUMErrorEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventApplication * _Nonnull application;
		[Export ("application", ArgumentSemantic.Strong)]
		DDRUMErrorEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMErrorEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMErrorEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventError * _Nonnull error;
		[Export ("error", ArgumentSemantic.Strong)]
		DDRUMErrorEventError Error { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventFeatureFlags * _Nullable featureFlags;
		[NullAllowed, Export ("featureFlags", ArgumentSemantic.Strong)]
		DDRUMErrorEventFeatureFlags FeatureFlags { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventFreeze * _Nullable freeze;
		[NullAllowed, Export ("freeze", ArgumentSemantic.Strong)]
		DDRUMErrorEventFreeze Freeze { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMErrorEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventSource source;
		[Export ("source")]
		DDRUMErrorEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMErrorEventView View { get; }
	}

	// @interface DDRUMErrorEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMErrorEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary AccountInfo { get; set; }
	}

	// @interface DDRUMErrorEventAction : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMErrorEventAction")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventAction
	{
		// @property (readonly, nonatomic, strong) DDRUMErrorEventActionRUMActionID * _Nonnull id;
		[Export ("id", ArgumentSemantic.Strong)]
		DDRUMErrorEventActionRUMActionID Id { get; }
	}

	// @interface DDRUMErrorEventActionRUMActionID : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMErrorEventActionRUMActionID")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventActionRUMActionID
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable stringsArray;
		[NullAllowed, Export ("stringsArray", ArgumentSemantic.Copy)]
		string[] StringsArray { get; }
	}

	// @interface DDRUMErrorEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMErrorEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMErrorEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMErrorEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMErrorEventContainerSource source;
		[Export ("source")]
		DDRUMErrorEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMErrorEventContainerView View { get; }
	}

	// @interface DDRUMErrorEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDRUMErrorEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMErrorEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc17DDRUMErrorEventDD")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventDD
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		DDRUMErrorEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMErrorEventDDSession Session { get; }
	}

	// @interface DDRUMErrorEventDDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMErrorEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }
	}

	// @interface DDRUMErrorEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMErrorEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMErrorEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMErrorEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMErrorEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMErrorEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMErrorEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMErrorEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMErrorEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMErrorEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMErrorEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMErrorEventError : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDRUMErrorEventError")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventError
	{
		// @property (readonly, copy, nonatomic) NSArray<DDRUMErrorEventErrorBinaryImages *> * _Nullable binaryImages;
		[NullAllowed, Export ("binaryImages", ArgumentSemantic.Copy)]
		DDRUMErrorEventErrorBinaryImages[] BinaryImages { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorCategory category;
		[Export ("category")]
		DDRUMErrorEventErrorCategory Category { get; }

		// @property (copy, nonatomic) NSArray<DDRUMErrorEventErrorCauses *> * _Nullable causes;
		[NullAllowed, Export ("causes", ArgumentSemantic.Copy)]
		DDRUMErrorEventErrorCauses[] Causes { get; set; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventErrorCSP * _Nullable csp;
		[NullAllowed, Export ("csp", ArgumentSemantic.Strong)]
		DDRUMErrorEventErrorCSP CSP { get; }

		// @property (copy, nonatomic) NSString * _Nullable fingerprint;
		[NullAllowed, Export ("fingerprint")]
		string Fingerprint { get; set; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorHandling handling;
		[Export ("handling")]
		DDRUMErrorEventErrorHandling Handling { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable handlingStack;
		[NullAllowed, Export ("handlingStack")]
		string HandlingStack { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isCrash;
		[NullAllowed, Export ("isCrash", ArgumentSemantic.Strong)]
		NSNumber IsCrash { get; }

		// @property (copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; set; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventErrorMeta * _Nullable meta;
		[NullAllowed, Export ("meta", ArgumentSemantic.Strong)]
		DDRUMErrorEventErrorMeta Meta { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventErrorResource * _Nullable resource;
		[NullAllowed, Export ("resource", ArgumentSemantic.Strong)]
		DDRUMErrorEventErrorResource Resource { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorSource source;
		[Export ("source")]
		DDRUMErrorEventErrorSource Source { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorSourceType sourceType;
		[Export ("sourceType")]
		DDRUMErrorEventErrorSourceType SourceType { get; }

		// @property (copy, nonatomic) NSString * _Nullable stack;
		[NullAllowed, Export ("stack")]
		string Stack { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<DDRUMErrorEventErrorThreads *> * _Nullable threads;
		[NullAllowed, Export ("threads", ArgumentSemantic.Copy)]
		DDRUMErrorEventErrorThreads[] Threads { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable timeSinceAppStart;
		[NullAllowed, Export ("timeSinceAppStart", ArgumentSemantic.Strong)]
		NSNumber TimeSinceAppStart { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable type;
		[NullAllowed, Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable wasTruncated;
		[NullAllowed, Export ("wasTruncated", ArgumentSemantic.Strong)]
		NSNumber WasTruncated { get; }
	}

	// @interface DDRUMErrorEventErrorBinaryImages : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMErrorEventErrorBinaryImages")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorBinaryImages
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable arch;
		[NullAllowed, Export ("arch")]
		string Arch { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull isSystem;
		[Export ("isSystem", ArgumentSemantic.Strong)]
		NSNumber IsSystem { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable loadAddress;
		[NullAllowed, Export ("loadAddress")]
		string LoadAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable maxAddress;
		[NullAllowed, Export ("maxAddress")]
		string MaxAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull uuid;
		[Export ("uuid")]
		string Uuid { get; }
	}

	// @interface DDRUMErrorEventErrorCSP : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMErrorEventErrorCSP")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorCSP
	{
		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorCSPDisposition disposition;
		[Export ("disposition")]
		DDRUMErrorEventErrorCSPDisposition Disposition { get; }
	}

	// @interface DDRUMErrorEventErrorCauses : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMErrorEventErrorCauses")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorCauses
	{
		// @property (copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; set; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorCausesSource source;
		[Export ("source")]
		DDRUMErrorEventErrorCausesSource Source { get; }

		// @property (copy, nonatomic) NSString * _Nullable stack;
		[NullAllowed, Export ("stack")]
		string Stack { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable type;
		[NullAllowed, Export ("type")]
		string Type { get; }
	}

	// @interface DDRUMErrorEventErrorMeta : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMErrorEventErrorMeta")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorMeta
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable codeType;
		[NullAllowed, Export ("codeType")]
		string CodeType { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable exceptionCodes;
		[NullAllowed, Export ("exceptionCodes")]
		string ExceptionCodes { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable exceptionType;
		[NullAllowed, Export ("exceptionType")]
		string ExceptionType { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable incidentIdentifier;
		[NullAllowed, Export ("incidentIdentifier")]
		string IncidentIdentifier { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable parentProcess;
		[NullAllowed, Export ("parentProcess")]
		string ParentProcess { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable process;
		[NullAllowed, Export ("process")]
		string Process { get; }
	}

	// @interface DDRUMErrorEventErrorResource : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDRUMErrorEventErrorResource")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorResource
	{
		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorResourceRUMMethod method;
		[Export ("method")]
		DDRUMErrorEventErrorResourceRUMMethod Method { get; }

		// @property (readonly, nonatomic, strong) DDRUMErrorEventErrorResourceProvider * _Nullable provider;
		[NullAllowed, Export ("provider", ArgumentSemantic.Strong)]
		DDRUMErrorEventErrorResourceProvider Provider { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull statusCode;
		[Export ("statusCode", ArgumentSemantic.Strong)]
		NSNumber StatusCode { get; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMErrorEventErrorResourceProvider : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDRUMErrorEventErrorResourceProvider")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorResourceProvider
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable domain;
		[NullAllowed, Export ("domain")]
		string Domain { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventErrorResourceProviderProviderType type;
		[Export ("type")]
		DDRUMErrorEventErrorResourceProviderProviderType Type { get; }
	}

	// @interface DDRUMErrorEventErrorThreads : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMErrorEventErrorThreads")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventErrorThreads
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull crashed;
		[Export ("crashed", ArgumentSemantic.Strong)]
		NSNumber Crashed { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull stack;
		[Export ("stack")]
		string Stack { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export ("state")]
		string State { get; }
	}

	// @interface DDRUMErrorEventFeatureFlags : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMErrorEventFeatureFlags")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventFeatureFlags
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull featureFlagsInfo;
		[Export ("featureFlagsInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> FeatureFlagsInfo { get; set; }
	}

	// @interface DDRUMErrorEventFreeze : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMErrorEventFreeze")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventFreeze
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }
	}

	// @interface DDRUMErrorEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMErrorEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMErrorEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMErrorEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMErrorEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMErrorEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMErrorEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMErrorEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMErrorEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc38DDRUMErrorEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMErrorEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMErrorEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMErrorEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMErrorEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMErrorEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMErrorEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMErrorEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMErrorEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMErrorEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMErrorEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMErrorEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMErrorEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMErrorEventSession")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMErrorEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMErrorEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMErrorEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc19DDRUMErrorEventView")]
	[DisableDefaultCtor]
	interface DDRUMErrorEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable inForeground;
		[NullAllowed, Export ("inForeground", ArgumentSemantic.Strong)]
		NSNumber InForeground { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export ("referrer")]
		string Referrer { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMFirstPartyHostsTracing : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMFirstPartyHostsTracing")]
	[DisableDefaultCtor]
	interface DDRUMFirstPartyHostsTracing
	{
		// -(instancetype _Nonnull)initWithHostsWithHeaderTypes:(NSDictionary<NSString *,NSSet<DDTracingHeaderType *> *> * _Nonnull)hostsWithHeaderTypes __attribute__((objc_designated_initializer));
		[Export ("initWithHostsWithHeaderTypes:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSDictionary<NSString, NSSet<DDTracingHeaderType>> hostsWithHeaderTypes);

		// -(instancetype _Nonnull)initWithHostsWithHeaderTypes:(NSDictionary<NSString *,NSSet<DDTracingHeaderType *> *> * _Nonnull)hostsWithHeaderTypes sampleRate:(float)sampleRate __attribute__((objc_designated_initializer));
		[Export ("initWithHostsWithHeaderTypes:sampleRate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSDictionary<NSString, NSSet<DDTracingHeaderType>> hostsWithHeaderTypes, float sampleRate);

		// -(instancetype _Nonnull)initWithHosts:(NSSet<NSString *> * _Nonnull)hosts __attribute__((objc_designated_initializer));
		[Export ("initWithHosts:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSString> hosts);

		// -(instancetype _Nonnull)initWithHosts:(NSSet<NSString *> * _Nonnull)hosts sampleRate:(float)sampleRate __attribute__((objc_designated_initializer));
		[Export ("initWithHosts:sampleRate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSString> hosts, float sampleRate);
	}

	// @interface DDRUMLongTaskEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc18DDRUMLongTaskEvent")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventDD DD { get; }

		// @property (nonatomic, readonly, strong) DDRUMLongTaskEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventAction * _Nullable action;
		[NullAllowed, Export("action", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventApplication * _Nonnull application;
		[Export ("application", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventLongTask * _Nonnull longTask;
		[Export ("longTask", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventLongTask LongTask { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventSource source;
		[Export ("source")]
		DDRUMLongTaskEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventView View { get; }
	}

	// @interface DDRUMLongTaskEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMLongTaskEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccountInfo { get; set; }
	}

	// @interface DDRUMLongTaskEventAction : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMLongTaskEventAction")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventAction
	{
		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventActionRUMActionID * _Nonnull id;
		[Export ("id", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventActionRUMActionID Id { get; }
	}

	// @interface DDRUMLongTaskEventActionRUMActionID : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMLongTaskEventActionRUMActionID")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventActionRUMActionID
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable stringsArray;
		[NullAllowed, Export ("stringsArray", ArgumentSemantic.Copy)]
		string[] StringsArray { get; }
	}

	// @interface DDRUMLongTaskEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMLongTaskEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMLongTaskEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMLongTaskEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMLongTaskEventContainerSource source;
		[Export ("source")]
		DDRUMLongTaskEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventContainerView View { get; }
	}

	// @interface DDRUMLongTaskEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMLongTaskEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMLongTaskEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDRUMLongTaskEventDD")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventDD
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable discarded;
		[NullAllowed, Export ("discarded", ArgumentSemantic.Strong)]
		NSNumber Discarded { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventDDSession Session { get; }
	}

	// @interface DDRUMLongTaskEventDDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMLongTaskEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }
	}

	// @interface DDRUMLongTaskEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMLongTaskEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMLongTaskEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMLongTaskEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMLongTaskEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMLongTaskEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMLongTaskEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMLongTaskEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMLongTaskEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMLongTaskEventLongTask : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMLongTaskEventLongTask")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventLongTask
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable blockingDuration;
		[NullAllowed, Export ("blockingDuration", ArgumentSemantic.Strong)]
		NSNumber BlockingDuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventLongTaskEntryType entryType;
		[Export ("entryType")]
		DDRUMLongTaskEventLongTaskEntryType EntryType { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable firstUiEventTimestamp;
		[NullAllowed, Export ("firstUiEventTimestamp", ArgumentSemantic.Strong)]
		NSNumber FirstUiEventTimestamp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isFrozenFrame;
		[NullAllowed, Export ("isFrozenFrame", ArgumentSemantic.Strong)]
		NSNumber IsFrozenFrame { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable renderStart;
		[NullAllowed, Export ("renderStart", ArgumentSemantic.Strong)]
		NSNumber RenderStart { get; }

		// @property (readonly, copy, nonatomic) NSArray<DDRUMLongTaskEventLongTaskScripts *> * _Nullable scripts;
		[NullAllowed, Export ("scripts", ArgumentSemantic.Copy)]
		DDRUMLongTaskEventLongTaskScripts[] Scripts { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable startTime;
		[NullAllowed, Export ("startTime", ArgumentSemantic.Strong)]
		NSNumber StartTime { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable styleAndLayoutStart;
		[NullAllowed, Export ("styleAndLayoutStart", ArgumentSemantic.Strong)]
		NSNumber StyleAndLayoutStart { get; }
	}

	// @interface DDRUMLongTaskEventLongTaskScripts : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMLongTaskEventLongTaskScripts")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventLongTaskScripts
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable duration;
		[NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable executionStart;
		[NullAllowed, Export ("executionStart", ArgumentSemantic.Strong)]
		NSNumber ExecutionStart { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable forcedStyleAndLayoutDuration;
		[NullAllowed, Export ("forcedStyleAndLayoutDuration", ArgumentSemantic.Strong)]
		NSNumber ForcedStyleAndLayoutDuration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable invoker;
		[NullAllowed, Export ("invoker")]
		string Invoker { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventLongTaskScriptsInvokerType invokerType;
		[Export ("invokerType")]
		DDRUMLongTaskEventLongTaskScriptsInvokerType InvokerType { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable pauseDuration;
		[NullAllowed, Export ("pauseDuration", ArgumentSemantic.Strong)]
		NSNumber PauseDuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sourceCharPosition;
		[NullAllowed, Export ("sourceCharPosition", ArgumentSemantic.Strong)]
		NSNumber SourceCharPosition { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceFunctionName;
		[NullAllowed, Export ("sourceFunctionName")]
		string SourceFunctionName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceUrl;
		[NullAllowed, Export ("sourceUrl")]
		string SourceUrl { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable startTime;
		[NullAllowed, Export ("startTime", ArgumentSemantic.Strong)]
		NSNumber StartTime { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable windowAttribution;
		[NullAllowed, Export ("windowAttribution")]
		string WindowAttribution { get; }
	}

	// @interface DDRUMLongTaskEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMLongTaskEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMLongTaskEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMLongTaskEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMLongTaskEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMLongTaskEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMLongTaskEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMLongTaskEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMLongTaskEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc41DDRUMLongTaskEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMLongTaskEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMLongTaskEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMLongTaskEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMLongTaskEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDRUMLongTaskEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMLongTaskEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDRUMLongTaskEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMLongTaskEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMLongTaskEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMLongTaskEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMLongTaskEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMLongTaskEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMLongTaskEventSession")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMLongTaskEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMLongTaskEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMLongTaskEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMLongTaskEventView")]
	[DisableDefaultCtor]
	interface DDRUMLongTaskEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export ("referrer")]
		string Referrer { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMMonitor : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc12DDRUMMonitor")]
	[DisableDefaultCtor]
	interface DDRUMMonitor
	{
		// +(DDRUMMonitor * _Nonnull)shared __attribute__((warn_unused_result("")));
		[Static]
		[Export ("shared")]
		DDRUMMonitor Shared { get; }

		// -(void)currentSessionIDWithCompletion:(void (^ _Nonnull)(NSString * _Nullable))completion;
		[Export ("currentSessionIDWithCompletion:")]
		void GetCurrentSessionIdViaCallback (Action<NSString> callback);

		// -(void)stopSession;
		[Export ("stopSession")]
		void StopSession ();

		// -(void)startViewWithViewController:(UIViewController * _Nonnull)viewController name:(NSString * _Nullable)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startViewWithViewController:name:attributes:")]
		void StartView (UIViewController viewController, [NullAllowed] string name, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopViewWithViewController:(UIViewController * _Nonnull)viewController attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopViewWithViewController:attributes:")]
		void StopView (UIViewController viewController, NSDictionary<NSString, NSObject> attributes);

		// -(void)startViewWithKey:(NSString * _Nonnull)key name:(NSString * _Nullable)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startViewWithKey:name:attributes:")]
		void StartView (string key, [NullAllowed] string name, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopViewWithKey:(NSString * _Nonnull)key attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopViewWithKey:attributes:")]
		void StopView (string key, NSDictionary<NSString, NSObject> attributes);

		// -(void)addTimingWithName:(NSString * _Nonnull)name;
		[Export ("addTimingWithName:")]
		void AddTiming (string name);

		// -(void)addErrorWithMessage:(NSString * _Nonnull)message stack:(NSString * _Nullable)stack source:(enum DDRUMErrorSource)source attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("addErrorWithMessage:stack:source:attributes:")]
		void AddError (string message, [NullAllowed] string stack, DDRUMErrorSource source, NSDictionary<NSString, NSObject> attributes);

		// -(void)addErrorWithError:(NSError * _Nonnull)error source:(enum DDRUMErrorSource)source attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("addErrorWithError:source:attributes:")]
		void AddError (NSError error, DDRUMErrorSource source, NSDictionary<NSString, NSObject> attributes);

		// -(void)startResourceWithResourceKey:(NSString * _Nonnull)resourceKey request:(NSURLRequest * _Nonnull)request attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startResourceWithResourceKey:request:attributes:")]
		void StartResource (string resourceKey, NSUrlRequest request, NSDictionary<NSString, NSObject> attributes);

		// -(void)startResourceWithResourceKey:(NSString * _Nonnull)resourceKey url:(NSURL * _Nonnull)url attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startResourceWithResourceKey:url:attributes:")]
		void StartResource(string resourceKey, NSUrl url, NSDictionary<NSString, NSObject> attributes);

		// -(void)startResourceWithResourceKey:(NSString * _Nonnull)resourceKey httpMethod:(enum DDRUMMethod)httpMethod urlString:(NSString * _Nonnull)urlString attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startResourceWithResourceKey:httpMethod:urlString:attributes:")]
		void StartResource (string resourceKey, DDRUMMethod httpMethod, string urlString, NSDictionary<NSString, NSObject> attributes);

		// -(void)addResourceMetricsWithResourceKey:(NSString * _Nonnull)resourceKey metrics:(NSURLSessionTaskMetrics * _Nonnull)metrics attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("addResourceMetricsWithResourceKey:metrics:attributes:")]
		void AddResourceMetrics(string resourceKey, NSUrlSessionTaskMetrics metrics, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopResourceWithResourceKey:(NSString * _Nonnull)resourceKey response:(NSURLResponse * _Nonnull)response size:(NSNumber * _Nullable)size attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopResourceWithResourceKey:response:size:attributes:")]
		void StopResource(string resourceKey, NSUrlResponse response, [NullAllowed] NSNumber size, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopResourceWithResourceKey:(NSString * _Nonnull)resourceKey statusCode:(NSNumber * _Nullable)statusCode kind:(enum DDRUMResourceType)kind size:(NSNumber * _Nullable)size attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopResourceWithResourceKey:statusCode:kind:size:attributes:")]
		void StopResource(string resourceKey, [NullAllowed] NSNumber statusCode, DDRUMResourceType kind, [NullAllowed] NSNumber size, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopResourceWithErrorWithResourceKey:(NSString * _Nonnull)resourceKey error:(NSError * _Nonnull)error response:(NSURLResponse * _Nullable)response attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopResourceWithErrorWithResourceKey:error:response:attributes:")]
		void StopResource(string resourceKey, NSError error, [NullAllowed] NSUrlResponse response, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopResourceWithErrorWithResourceKey:(NSString * _Nonnull)resourceKey message:(NSString * _Nonnull)message response:(NSURLResponse * _Nullable)response attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopResourceWithErrorWithResourceKey:message:response:attributes:")]
		void StopResource(string resourceKey, string message, [NullAllowed] NSUrlResponse response, NSDictionary<NSString, NSObject> attributes);

		// -(void)startActionWithType:(enum DDRUMActionType)type name:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("startActionWithType:name:attributes:")]
		void StartAction(DDRUMActionType type, string name, NSDictionary<NSString, NSObject> attributes);

		// -(void)stopActionWithType:(enum DDRUMActionType)type name:(NSString * _Nullable)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("stopActionWithType:name:attributes:")]
		void StopAction(DDRUMActionType type, [NullAllowed] string name, NSDictionary<NSString, NSObject> attributes);

		// -(void)addActionWithType:(enum DDRUMActionType)type name:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes;
		[Export ("addActionWithType:name:attributes:")]
		void AddAction(DDRUMActionType type, string name, NSDictionary<NSString, NSObject> attributes);

		// -(void)addAttributeForKey:(NSString * _Nonnull)key value:(id _Nonnull)value;
		[Export ("addAttributeForKey:value:")]
		void AddAttribute(string key, NSObject value);

		// -(void)addAttributes:(NSDictionary<NSString *, id> * _Nonnull)attributes;
		[Export("addAttributes:")]
		void AddAttributes(NSDictionary<NSString, NSObject> attributes);

		// -(void)removeAttributesForKeys:(NSArray<NSString *> * _Nonnull)keys;
		[Export("removeAttributesForKeys:")]
		void RemoveAttributes (string[] keys);

		// -(void)removeAttributeForKey:(NSString * _Nonnull)key;
		[Export("removeAttributeForKey:")]
		void RemoveAttribute(string key);

		// -(void)addFeatureFlagEvaluationWithName:(NSString * _Nonnull)name value:(id _Nonnull)value;
		[Export ("addFeatureFlagEvaluationWithName:value:")]
		void AddFeatureFlagEvaluation (string name, NSObject value);

		// @property (nonatomic) BOOL debug;
		[Export ("debug")]
		bool Debug { get; set; }
	}

	// @interface DDRUMResourceEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc18DDRUMResourceEvent")]
	[DisableDefaultCtor]
	interface DDRUMResourceEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMResourceEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMResourceEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMResourceEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventAction * _Nullable action;
		[NullAllowed, Export("action", ArgumentSemantic.Strong)]
		DDRUMResourceEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventApplication * _Nonnull application;
		[Export ("application", ArgumentSemantic.Strong)]
		DDRUMResourceEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMResourceEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMResourceEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMOperatingSystem OS { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResource * _Nonnull resource;
		[Export ("resource", ArgumentSemantic.Strong)]
		DDRUMResourceEventResource Resource { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMResourceEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventSource source;
		[Export ("source")]
		DDRUMResourceEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMResourceEventView View { get; }
	}

	// @interface DDRUMResourceEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMResourceEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccountInfo { get; set; }
	}

	// @interface DDRUMResourceEventAction : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMResourceEventAction")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventAction
	{
		// @property (readonly, nonatomic, strong) DDRUMResourceEventActionRUMActionID * _Nonnull id;
		[Export ("id", ArgumentSemantic.Strong)]
		DDRUMResourceEventActionRUMActionID Id { get; }
	}

	// @interface DDRUMResourceEventActionRUMActionID : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMResourceEventActionRUMActionID")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventActionRUMActionID
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable stringsArray;
		[NullAllowed, Export ("stringsArray", ArgumentSemantic.Copy)]
		string[] StringsArray { get; }
	}

	// @interface DDRUMResourceEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMResourceEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMResourceEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMResourceEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMResourceEventContainerSource source;
		[Export ("source")]
		DDRUMResourceEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMResourceEventContainerView View { get; }
	}

	// @interface DDRUMResourceEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMResourceEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMResourceEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDRUMResourceEventDD")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventDD
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		DDRUMResourceEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable discarded;
		[NullAllowed, Export ("discarded", ArgumentSemantic.Strong)]
		NSNumber Discarded { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable rulePsr;
		[NullAllowed, Export ("rulePsr", ArgumentSemantic.Strong)]
		NSNumber RulePsr { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMResourceEventDDSession Session { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable spanId;
		[NullAllowed, Export ("spanId")]
		string SpanId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable traceId;
		[NullAllowed, Export ("traceId")]
		string TraceId { get; }
	}

	// @interface DDRUMResourceEventDDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMResourceEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }
	}

	// @interface DDRUMResourceEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMResourceEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMResourceEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMResourceEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMResourceEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMResourceEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMResourceEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMResourceEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMResourceEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMResourceEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMResourceEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMResourceEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMResourceEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMResourceEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMResourceEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMResourceEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMResourceEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMResourceEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMResourceEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMResourceEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc41DDRUMResourceEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMResourceEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMResourceEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMResourceEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMResourceEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDRUMResourceEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMResourceEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDRUMResourceEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMResourceEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMResourceEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMResourceEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMResourceEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMResourceEventResource : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMResourceEventResource")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResource
	{
		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceConnect * _Nullable connect;
		[NullAllowed, Export ("connect", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceConnect Connect { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable decodedBodySize;
		[NullAllowed, Export ("decodedBodySize", ArgumentSemantic.Strong)]
		NSNumber DecodedBodySize { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceDeliveryType deliveryType;
		[Export ("deliveryType")]
		DDRUMResourceEventResourceDeliveryType DeliveryType { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceDNS * _Nullable dns;
		[NullAllowed, Export ("dns", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceDNS DNS { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceDownload * _Nullable download;
		[NullAllowed, Export ("download", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceDownload Download { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable duration;
		[NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable encodedBodySize;
		[NullAllowed, Export ("encodedBodySize", ArgumentSemantic.Strong)]
		NSNumber EncodedBodySize { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceFirstByte * _Nullable firstByte;
		[NullAllowed, Export ("firstByte", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceFirstByte FirstByte { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceGraphql * _Nullable graphql;
		[NullAllowed, Export ("graphql", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceGraphql GraphQL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceRUMMethod method;
		[Export ("method")]
		DDRUMResourceEventResourceRUMMethod Method { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable protocol;
		[NullAllowed, Export ("protocol")]
		string Protocol { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceProvider * _Nullable provider;
		[NullAllowed, Export ("provider", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceProvider Provider { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceRedirect * _Nullable redirect;
		[NullAllowed, Export ("redirect", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceRedirect Redirect { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceRenderBlockingStatus renderBlockingStatus;
		[Export ("renderBlockingStatus")]
		DDRUMResourceEventResourceRenderBlockingStatus RenderBlockingStatus { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable size;
		[NullAllowed, Export ("size", ArgumentSemantic.Strong)]
		NSNumber Size { get; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceSSL * _Nullable ssl;
		[NullAllowed, Export ("ssl", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceSSL SSL { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable statusCode;
		[NullAllowed, Export ("statusCode", ArgumentSemantic.Strong)]
		NSNumber StatusCode { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable transferSize;
		[NullAllowed, Export ("transferSize", ArgumentSemantic.Strong)]
		NSNumber TransferSize { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceResourceType type;
		[Export ("type")]
		DDRUMResourceEventResourceResourceType Type { get; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }

		// @property (readonly, nonatomic, strong) DDRUMResourceEventResourceWorker * _Nullable worker;
		[NullAllowed, Export ("worker", ArgumentSemantic.Strong)]
		DDRUMResourceEventResourceWorker Worker { get; }
	}

	// @interface DDRUMResourceEventResourceConnect : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMResourceEventResourceConnect")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceConnect
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceDNS : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMResourceEventResourceDNS")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceDNS
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceDownload : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMResourceEventResourceDownload")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceDownload
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceFirstByte : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMResourceEventResourceFirstByte")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceFirstByte
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceGraphql : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMResourceEventResourceGraphql")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceGraphql
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable operationName;
		[NullAllowed, Export ("operationName")]
		string OperationName { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceGraphqlOperationType operationType;
		[Export ("operationType")]
		DDRUMResourceEventResourceGraphqlOperationType OperationType { get; }

		// @property (copy, nonatomic) NSString * _Nullable payload;
		[NullAllowed, Export ("payload")]
		string Payload { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable variables;
		[NullAllowed, Export ("variables")]
		string Variables { get; set; }
	}

	// @interface DDRUMResourceEventResourceProvider : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMResourceEventResourceProvider")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceProvider
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable domain;
		[NullAllowed, Export ("domain")]
		string Domain { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventResourceProviderProviderType type;
		[Export ("type")]
		DDRUMResourceEventResourceProviderProviderType Type { get; }
	}

	// @interface DDRUMResourceEventResourceRedirect : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMResourceEventResourceRedirect")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceRedirect
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceSSL : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMResourceEventResourceSSL")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceSSL
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventResourceWorker : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMResourceEventResourceWorker")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventResourceWorker
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMResourceEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMResourceEventSession")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMResourceEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMResourceEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMResourceEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMResourceEventView")]
	[DisableDefaultCtor]
	interface DDRUMResourceEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export ("referrer")]
		string Referrer { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMURLSessionTracking : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMURLSessionTracking")]
	interface DDRUMURLSessionTracking
	{
		// -(void)setFirstPartyHostsTracing:(DDRUMFirstPartyHostsTracing * _Nonnull)firstPartyHostsTracing;
		[Export ("setFirstPartyHostsTracing:")]
		void SetFirstPartyHostsTracing (DDRUMFirstPartyHostsTracing firstPartyHostsTracing);

		// -(void)setResourceAttributesProvider:(NSDictionary<NSString *,id> * _Nullable (^ _Nonnull)(NSURLRequest * _Nonnull, NSURLResponse * _Nullable, NSData * _Nullable, NSError * _Nullable))provider;
		[Export ("setResourceAttributesProvider:")]
		void SetResourceAttributesProvider (Func<NSUrlRequest, NSUrlResponse, NSData, NSError, NSDictionary<NSString, NSObject>> provider);
	}

	// @interface DDRUMView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc9DDRUMView")]
	[DisableDefaultCtor]
	interface DDRUMView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
		[Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithName:attributes:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string name, NSDictionary<NSString, NSObject> attributes);
	}

	// @interface DDRUMViewEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc14DDRUMViewEvent")]
	[DisableDefaultCtor]
	interface DDRUMViewEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMViewEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMViewEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMViewEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventApplication * _Nonnull application;
		[Export("application", ArgumentSemantic.Strong)]
		DDRUMViewEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMViewEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMViewEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventFeatureFlags * _Nullable featureFlags;
		[NullAllowed, Export ("featureFlags", ArgumentSemantic.Strong)]
		DDRUMViewEventFeatureFlags FeatureFlags { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMOperatingSystem OS { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventPrivacy * _Nullable privacy;
		[NullAllowed, Export ("privacy", ArgumentSemantic.Strong)]
		DDRUMViewEventPrivacy Privacy { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMViewEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventSource source;
		[Export ("source")]
		DDRUMViewEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMViewEventView View { get; }
	}

	// @interface DDRUMViewEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMViewEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMViewEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccountInfo { get; set; }
	}

	// @interface DDRUMViewEventApplication : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc25DDRUMViewEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMViewEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMViewEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMViewEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMViewEventContainerSource source;
		[Export ("source")]
		DDRUMViewEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMViewEventContainerView View { get; }
	}

	// @interface DDRUMViewEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMViewEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMViewEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMViewEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc16DDRUMViewEventDD")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDD
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventDDCLS * _Nullable cls;
		[NullAllowed, Export("cls", ArgumentSemantic.Strong)]
		DDRUMViewEventDDCLS Cls { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export("configuration", ArgumentSemantic.Strong)]
		DDRUMViewEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull documentVersion;
		[Export ("documentVersion", ArgumentSemantic.Strong)]
		NSNumber DocumentVersion { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, copy, nonatomic) NSArray<DDRUMViewEventDDPageStates *> * _Nullable pageStates;
		[NullAllowed, Export ("pageStates", ArgumentSemantic.Copy)]
		DDRUMViewEventDDPageStates[] PageStates { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventDDReplayStats * _Nullable replayStats;
		[NullAllowed, Export ("replayStats", ArgumentSemantic.Strong)]
		DDRUMViewEventDDReplayStats ReplayStats { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMViewEventDDSession Session { get; }
	}

	// @interface DDRUMViewEventDDCLS : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc19DDRUMViewEventDDCLS")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDDCLS
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nullable devicePixelRatio;
		[NullAllowed, Export("devicePixelRatio", ArgumentSemantic.Strong)]
		NSNumber DevicePixelRatio { get; }
	}

	// @interface DDRUMViewEventDDConfiguration : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable startSessionReplayRecordingManually;
		[NullAllowed, Export ("startSessionReplayRecordingManually", ArgumentSemantic.Strong)]
		NSNumber StartSessionReplayRecordingManually { get; }
	}

	// @interface DDRUMViewEventDDPageStates : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMViewEventDDPageStates")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDDPageStates
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventDDPageStatesState state;
		[Export ("state")]
		DDRUMViewEventDDPageStatesState State { get; }
	}

	// @interface DDRUMViewEventDDReplayStats : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMViewEventDDReplayStats")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDDReplayStats
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable recordsCount;
		[NullAllowed, Export ("recordsCount", ArgumentSemantic.Strong)]
		NSNumber RecordsCount { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable segmentsCount;
		[NullAllowed, Export ("segmentsCount", ArgumentSemantic.Strong)]
		NSNumber SegmentsCount { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable segmentsTotalRawSize;
		[NullAllowed, Export ("segmentsTotalRawSize", ArgumentSemantic.Strong)]
		NSNumber SegmentsTotalRawSize { get; }
	}

	// @interface DDRUMViewEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMViewEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMViewEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMViewEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMViewEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMViewEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMViewEventDisplayScroll * _Nullable scroll;
		[NullAllowed, Export ("scroll", ArgumentSemantic.Strong)]
		DDRUMViewEventDisplayScroll Scroll { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMViewEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMViewEventDisplayScroll : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDRUMViewEventDisplayScroll")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDisplayScroll
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull maxDepth;
		[Export ("maxDepth", ArgumentSemantic.Strong)]
		NSNumber MaxDepth { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull maxDepthScrollTop;
		[Export ("maxDepthScrollTop", ArgumentSemantic.Strong)]
		NSNumber MaxDepthScrollTop { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull maxScrollHeight;
		[Export ("maxScrollHeight", ArgumentSemantic.Strong)]
		NSNumber MaxScrollHeight { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull maxScrollHeightTime;
		[Export ("maxScrollHeightTime", ArgumentSemantic.Strong)]
		NSNumber MaxScrollHeightTime { get; }
	}

	// @interface DDRUMViewEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMViewEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMViewEventFeatureFlags : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMViewEventFeatureFlags")]
	[DisableDefaultCtor]
	interface DDRUMViewEventFeatureFlags
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull featureFlagsInfo;
		[Export ("featureFlagsInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> FeatureFlagsInfo { get; set; }
	}

	// @interface DDRUMViewEventPrivacy : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMViewEventPrivacy")]
	[DisableDefaultCtor]
	interface DDRUMViewEventPrivacy
	{
		// @property (readonly, nonatomic) enum DDRUMViewEventPrivacyReplayLevel replayLevel;
		[Export ("replayLevel")]
		DDRUMViewEventPrivacyReplayLevel ReplayLevel { get; }
	}

	// @interface DDRUMViewEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMViewEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMViewEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMViewEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMViewEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMViewEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMViewEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc37DDRUMViewEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMViewEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMViewEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMViewEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMViewEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMViewEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMViewEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMViewEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMViewEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMViewEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMViewEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDRUMViewEventSession")]
	[DisableDefaultCtor]
	interface DDRUMViewEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isActive;
		[NullAllowed, Export ("isActive", ArgumentSemantic.Strong)]
		NSNumber IsActive { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sampledForReplay;
		[NullAllowed, Export ("sampledForReplay", ArgumentSemantic.Strong)]
		NSNumber SampledForReplay { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMViewEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMViewEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc18DDRUMViewEventView")]
	[DisableDefaultCtor]
	interface DDRUMViewEventView
	{
		// @property (readonly, nonatomic, strong) DDRUMViewEventViewAction * _Nonnull action;
		[Export ("action", ArgumentSemantic.Strong)]
		DDRUMViewEventViewAction Action { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable cpuTicksCount;
		[NullAllowed, Export ("cpuTicksCount", ArgumentSemantic.Strong)]
		NSNumber CPUTicksCount { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable cpuTicksPerSecond;
		[NullAllowed, Export ("cpuTicksPerSecond", ArgumentSemantic.Strong)]
		NSNumber CPUTicksPerSecond { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewCrash * _Nullable crash;
		[NullAllowed, Export ("crash", ArgumentSemantic.Strong)]
		DDRUMViewEventViewCrash Crash { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable cumulativeLayoutShift;
		[NullAllowed, Export ("cumulativeLayoutShift", ArgumentSemantic.Strong)]
		NSNumber CumulativeLayoutShift { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable cumulativeLayoutShiftTargetSelector;
		[NullAllowed, Export ("cumulativeLayoutShiftTargetSelector")]
		string CumulativeLayoutShiftTargetSelector { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable cumulativeLayoutShiftTime;
		[NullAllowed, Export ("cumulativeLayoutShiftTime", ArgumentSemantic.Strong)]
		NSNumber CumulativeLayoutShiftTime { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSNumber *> * _Nullable customTimings;
		[NullAllowed, Export ("customTimings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSNumber> CustomTimings { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable domComplete;
		[NullAllowed, Export ("domComplete", ArgumentSemantic.Strong)]
		NSNumber DomComplete { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable domContentLoaded;
		[NullAllowed, Export ("domContentLoaded", ArgumentSemantic.Strong)]
		NSNumber DomContentLoaded { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable domInteractive;
		[NullAllowed, Export ("domInteractive", ArgumentSemantic.Strong)]
		NSNumber DomInteractive { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewError * _Nonnull error;
		[Export ("error", ArgumentSemantic.Strong)]
		DDRUMViewEventViewError Error { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable firstByte;
		[NullAllowed, Export ("firstByte", ArgumentSemantic.Strong)]
		NSNumber FirstByte { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable firstContentfulPaint;
		[NullAllowed, Export ("firstContentfulPaint", ArgumentSemantic.Strong)]
		NSNumber FirstContentfulPaint { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable firstInputDelay;
		[NullAllowed, Export ("firstInputDelay", ArgumentSemantic.Strong)]
		NSNumber FirstInputDelay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable firstInputTargetSelector;
		[NullAllowed, Export ("firstInputTargetSelector")]
		string FirstInputTargetSelector { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable firstInputTime;
		[NullAllowed, Export ("firstInputTime", ArgumentSemantic.Strong)]
		NSNumber FirstInputTime { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewFlutterBuildTime * _Nullable flutterBuildTime;
		[NullAllowed, Export ("flutterBuildTime", ArgumentSemantic.Strong)]
		DDRUMViewEventViewFlutterBuildTime FlutterBuildTime { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewFlutterRasterTime * _Nullable flutterRasterTime;
		[NullAllowed, Export ("flutterRasterTime", ArgumentSemantic.Strong)]
		DDRUMViewEventViewFlutterRasterTime FlutterRasterTime { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable freezeRate;
		[NullAllowed, Export("freezeRate", ArgumentSemantic.Strong)]
		NSNumber FreezeRate { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewFrozenFrame * _Nullable frozenFrame;
		[NullAllowed, Export("frozenFrame", ArgumentSemantic.Strong)]
		DDRUMViewEventViewFrozenFrame FrozenFrame { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewFrustration * _Nullable frustration;
		[NullAllowed, Export ("frustration", ArgumentSemantic.Strong)]
		DDRUMViewEventViewFrustration Frustration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSArray<DDRUMViewEventViewInForegroundPeriods *> * _Nullable inForegroundPeriods;
		[NullAllowed, Export ("inForegroundPeriods", ArgumentSemantic.Copy)]
		DDRUMViewEventViewInForegroundPeriods[] InForegroundPeriods { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable interactionToNextPaint;
		[NullAllowed, Export ("interactionToNextPaint", ArgumentSemantic.Strong)]
		NSNumber InteractionToNextPaint { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable interactionToNextPaintTargetSelector;
		[NullAllowed, Export ("interactionToNextPaintTargetSelector")]
		string InteractionToNextPaintTargetSelector { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable interactionToNextPaintTime;
		[NullAllowed, Export ("interactionToNextPaintTime", ArgumentSemantic.Strong)]
		NSNumber InteractionToNextPaintTime { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable interactionToNextViewTime;
		[NullAllowed, Export ("interactionToNextViewTime", ArgumentSemantic.Strong)]
		NSNumber InteractionToNextViewTime { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isActive;
		[NullAllowed, Export ("isActive", ArgumentSemantic.Strong)]
		NSNumber IsActive { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isSlowRendered;
		[NullAllowed, Export ("isSlowRendered", ArgumentSemantic.Strong)]
		NSNumber IsSlowRendered { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewJsRefreshRate * _Nullable jsRefreshRate;
		[NullAllowed, Export ("jsRefreshRate", ArgumentSemantic.Strong)]
		DDRUMViewEventViewJsRefreshRate JsRefreshRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable largestContentfulPaint;
		[NullAllowed, Export ("largestContentfulPaint", ArgumentSemantic.Strong)]
		NSNumber LargestContentfulPaint { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable largestContentfulPaintTargetSelector;
		[NullAllowed, Export ("largestContentfulPaintTargetSelector")]
		string LargestContentfulPaintTargetSelector { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable loadEvent;
		[NullAllowed, Export ("loadEvent", ArgumentSemantic.Strong)]
		NSNumber LoadEvent { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable loadingTime;
		[NullAllowed, Export ("loadingTime", ArgumentSemantic.Strong)]
		NSNumber LoadingTime { get; }

		// @property (readonly, nonatomic) enum DDRUMViewEventViewLoadingType loadingType;
		[Export ("loadingType")]
		DDRUMViewEventViewLoadingType LoadingType { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewLongTask * _Nullable longTask;
		[NullAllowed, Export ("longTask", ArgumentSemantic.Strong)]
		DDRUMViewEventViewLongTask LongTask { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable memoryAverage;
		[NullAllowed, Export ("memoryAverage", ArgumentSemantic.Strong)]
		NSNumber MemoryAverage { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable memoryMax;
		[NullAllowed, Export ("memoryMax", ArgumentSemantic.Strong)]
		NSNumber MemoryMax { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable networkSettledTime;
		[NullAllowed, Export ("networkSettledTime", ArgumentSemantic.Strong)]
		NSNumber NetworkSettledTime { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformance * _Nullable performance;
		[NullAllowed, Export("performance", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformance Performance { get; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export("referrer")]
		string Referrer { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable refreshRateAverage;
		[NullAllowed, Export ("refreshRateAverage", ArgumentSemantic.Strong)]
		NSNumber RefreshRateAverage { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable refreshRateMin;
		[NullAllowed, Export ("refreshRateMin", ArgumentSemantic.Strong)]
		NSNumber RefreshRateMin { get; }

		// @property (readonly, nonatomic, strong) DDRUMViewEventViewResource * _Nonnull resource;
		[Export ("resource", ArgumentSemantic.Strong)]
		DDRUMViewEventViewResource Resource { get; }

		// @property (nonatomic, readonly, copy) NSArray<DDRUMViewEventViewSlowFrames *> * _Nullable slowFrames;
		[NullAllowed, Export("slowFrames", ArgumentSemantic.Copy)]
		DDRUMViewEventViewSlowFrames[] SlowFrames { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable slowFramesRate;
		[NullAllowed, Export("slowFramesRate", ArgumentSemantic.Strong)]
		NSNumber SlowFramesRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull timeSpent;
		[Export("timeSpent", ArgumentSemantic.Strong)]
		NSNumber TimeSpent { get; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMViewEventViewAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMViewEventViewAction")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewAction
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewCrash : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventViewCrash")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewCrash
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewError : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDRUMViewEventViewError")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewError
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewFlutterBuildTime : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc34DDRUMViewEventViewFlutterBuildTime")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewFlutterBuildTime
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull average;
		[Export ("average", ArgumentSemantic.Strong)]
		NSNumber Average { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull max;
		[Export ("max", ArgumentSemantic.Strong)]
		NSNumber Max { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable metricMax;
		[NullAllowed, Export ("metricMax", ArgumentSemantic.Strong)]
		NSNumber MetricMax { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull min;
		[Export ("min", ArgumentSemantic.Strong)]
		NSNumber Min { get; }
	}

	// @interface DDRUMViewEventViewFlutterRasterTime : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDRUMViewEventViewFlutterRasterTime")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewFlutterRasterTime
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull average;
		[Export ("average", ArgumentSemantic.Strong)]
		NSNumber Average { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull max;
		[Export ("max", ArgumentSemantic.Strong)]
		NSNumber Max { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable metricMax;
		[NullAllowed, Export ("metricMax", ArgumentSemantic.Strong)]
		NSNumber MetricMax { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull min;
		[Export ("min", ArgumentSemantic.Strong)]
		NSNumber Min { get; }
	}

	// @interface DDRUMViewEventViewFrozenFrame : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventViewFrozenFrame")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewFrozenFrame
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewFrustration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventViewFrustration")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewFrustration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export ("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewInForegroundPeriods : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc37DDRUMViewEventViewInForegroundPeriods")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewInForegroundPeriods
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull duration;
		[Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMViewEventViewJsRefreshRate : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDRUMViewEventViewJsRefreshRate")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewJsRefreshRate
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull average;
		[Export ("average", ArgumentSemantic.Strong)]
		NSNumber Average { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull max;
		[Export ("max", ArgumentSemantic.Strong)]
		NSNumber Max { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable metricMax;
		[NullAllowed, Export ("metricMax", ArgumentSemantic.Strong)]
		NSNumber MetricMax { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull min;
		[Export ("min", ArgumentSemantic.Strong)]
		NSNumber Min { get; }
	}

	// @interface DDRUMViewEventViewLongTask : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMViewEventViewLongTask")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewLongTask
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewPerformance : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc29DDRUMViewEventViewPerformance")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformance
	{
		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceCLS * _Nullable cls;
		[NullAllowed, Export("cls", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceCLS Cls { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceFBC * _Nullable fbc;
		[NullAllowed, Export("fbc", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceFBC Fbc { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceFCP * _Nullable fcp;
		[NullAllowed, Export("fcp", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceFCP Fcp { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceFID * _Nullable fid;
		[NullAllowed, Export("fid", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceFID Fid { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceINP * _Nullable inp;
		[NullAllowed, Export("inp", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceINP Inp { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceLCP * _Nullable lcp;
		[NullAllowed, Export("lcp", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceLCP Lcp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceCLS : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceCLS")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceCLS
	{
		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceCLSCurrentRect * _Nullable currentRect;
		[NullAllowed, Export("currentRect", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceCLSCurrentRect CurrentRect { get; }

		// @property (nonatomic, readonly, strong) DDRUMViewEventViewPerformanceCLSPreviousRect * _Nullable previousRect;
		[NullAllowed, Export("previousRect", ArgumentSemantic.Strong)]
		DDRUMViewEventViewPerformanceCLSPreviousRect PreviousRect { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull score;
		[Export("score", ArgumentSemantic.Strong)]
		NSNumber Score { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable targetSelector;
		[NullAllowed, Export("targetSelector")]
		string TargetSelector { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable timestamp;
		[NullAllowed, Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceCLSCurrentRect : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc43DDRUMViewEventViewPerformanceCLSCurrentRect")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceCLSCurrentRect
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull height;
		[Export("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull width;
		[Export("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull x;
		[Export("x", ArgumentSemantic.Strong)]
		NSNumber X { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull y;
		[Export("y", ArgumentSemantic.Strong)]
		NSNumber Y { get; }
	}

	// @interface DDRUMViewEventViewPerformanceCLSPreviousRect : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc44DDRUMViewEventViewPerformanceCLSPreviousRect")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceCLSPreviousRect
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull height;
		[Export("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull width;
		[Export("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull x;
		[Export("x", ArgumentSemantic.Strong)]
		NSNumber X { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull y;
		[Export("y", ArgumentSemantic.Strong)]
		NSNumber Y { get; }
	}

	// @interface DDRUMViewEventViewPerformanceFBC : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceFBC")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceFBC
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull timestamp;
		[Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceFCP : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceFCP")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceFCP
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull timestamp;
		[Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceFID : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceFID")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceFID
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull duration;
		[Export("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable targetSelector;
		[NullAllowed, Export("targetSelector")]
		string TargetSelector { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull timestamp;
		[Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceINP : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceINP")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceINP
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull duration;
		[Export("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable targetSelector;
		[NullAllowed, Export("targetSelector")]
		string TargetSelector { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable timestamp;
		[NullAllowed, Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewPerformanceLCP : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMViewEventViewPerformanceLCP")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewPerformanceLCP
	{
		// @property (nonatomic, copy) NSString * _Nullable resourceUrl;
		[NullAllowed, Export("resourceUrl")]
		string ResourceUrl { get; set; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable targetSelector;
		[NullAllowed, Export("targetSelector")]
		string TargetSelector { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull timestamp;
		[Export("timestamp", ArgumentSemantic.Strong)]
		NSNumber Timestamp { get; }
	}

	// @interface DDRUMViewEventViewResource : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMViewEventViewResource")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewResource
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull count;
		[Export("count", ArgumentSemantic.Strong)]
		NSNumber Count { get; }
	}

	// @interface DDRUMViewEventViewSlowFrames : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc28DDRUMViewEventViewSlowFrames")]
	[DisableDefaultCtor]
	interface DDRUMViewEventViewSlowFrames
	{
		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull duration;
		[Export("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nonnull start;
		[Export("start", ArgumentSemantic.Strong)]
		NSNumber Start { get; }
	}

	// @interface DDRUMVitalEvent : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc15DDRUMVitalEvent")]
	[DisableDefaultCtor]
	interface DDRUMVitalEvent
	{
		// @property (readonly, nonatomic, strong) DDRUMVitalEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDRUMVitalEventDD DD { get; }

		// @property (nonatomic, readonly, strong) DDRUMVitalEventAccount * _Nullable account;
		[NullAllowed, Export("account", ArgumentSemantic.Strong)]
		DDRUMVitalEventAccount Account { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventApplication * _Nonnull application;
		[Export("application", ArgumentSemantic.Strong)]
		DDRUMVitalEventApplication Application { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildId;
		[NullAllowed, Export ("buildId")]
		string BuildId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable buildVersion;
		[NullAllowed, Export ("buildVersion")]
		string BuildVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMCITest * _Nullable ciTest;
		[NullAllowed, Export ("ciTest", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMCITest CITest { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMConnectivity * _Nullable connectivity;
		[NullAllowed, Export ("connectivity", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMConnectivity Connectivity { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventContainer * _Nullable container;
		[NullAllowed, Export ("container", ArgumentSemantic.Strong)]
		DDRUMVitalEventContainer Container { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMEventAttributes * _Nullable context;
		[NullAllowed, Export ("context", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMEventAttributes Context { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventDisplay * _Nullable display;
		[NullAllowed, Export ("display", ArgumentSemantic.Strong)]
		DDRUMVitalEventDisplay Display { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		DDRUMVitalEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventSource source;
		[Export ("source")]
		DDRUMVitalEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMSyntheticsTest * _Nullable synthetics;
		[NullAllowed, Export ("synthetics", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMSyntheticsTest Synthetics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMUser * _Nullable usr;
		[NullAllowed, Export ("usr", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMUser User { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMVitalEventView View { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventVital * _Nonnull vital;
		[Export ("vital", ArgumentSemantic.Strong)]
		DDRUMVitalEventVital Vital { get; }
	}

	// @interface DDRUMVitalEventAccount : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMVitalEventAccount")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventAccount
	{
		// @property (nonatomic, readonly, copy) NSString * _Nonnull id;
		[Export("id")]
		string Id { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (nonatomic, copy) NSDictionary<NSString *, id> * _Nonnull accountInfo;
		[Export("accountInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccountInfo { get; set; }
	}

	// @interface DDRUMVitalEventApplication : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC11DatadogObjc26DDRUMVitalEventApplication")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMVitalEventContainer : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMVitalEventContainer")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventContainer
	{
		// @property (readonly, nonatomic) enum DDRUMVitalEventContainerSource source;
		[Export ("source")]
		DDRUMVitalEventContainerSource Source { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventContainerView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		DDRUMVitalEventContainerView View { get; }
	}

	// @interface DDRUMVitalEventContainerView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDRUMVitalEventContainerView")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventContainerView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDRUMVitalEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc17DDRUMVitalEventDD")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDD
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable browserSdkVersion;
		[NullAllowed, Export ("browserSdkVersion")]
		string BrowserSdkVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventDDConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		DDRUMVitalEventDDConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventDDSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDRUMVitalEventDDSession Session { get; }

		// @property (readonly, nonatomic, strong) DDRUMVitalEventDDVital * _Nullable vital;
		[NullAllowed, Export ("vital", ArgumentSemantic.Strong)]
		DDRUMVitalEventDDVital Vital { get; }
	}

	// @interface DDRUMVitalEventDDConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMVitalEventDDConfiguration")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDDConfiguration
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export ("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull sessionSampleRate;
		[Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }
	}

	// @interface DDRUMVitalEventDDSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMVitalEventDDSession")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDDSession
	{
		// @property (readonly, nonatomic) enum DDRUMVitalEventDDSessionPlan plan;
		[Export ("plan")]
		DDRUMVitalEventDDSessionPlan Plan { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventDDSessionRUMSessionPrecondition sessionPrecondition;
		[Export ("sessionPrecondition")]
		DDRUMVitalEventDDSessionRUMSessionPrecondition SessionPrecondition { get; }
	}

	// @interface DDRUMVitalEventDDVital : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMVitalEventDDVital")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDDVital
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable computedValue;
		[NullAllowed, Export ("computedValue", ArgumentSemantic.Strong)]
		NSNumber ComputedValue { get; }
	}

	// @interface DDRUMVitalEventDisplay : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMVitalEventDisplay")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDisplay
	{
		// @property (readonly, nonatomic, strong) DDRUMVitalEventDisplayViewport * _Nullable viewport;
		[NullAllowed, Export ("viewport", ArgumentSemantic.Strong)]
		DDRUMVitalEventDisplayViewport Viewport { get; }
	}

	// @interface DDRUMVitalEventDisplayViewport : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMVitalEventDisplayViewport")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventDisplayViewport
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull height;
		[Export ("height", ArgumentSemantic.Strong)]
		NSNumber Height { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull width;
		[Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; }
	}

	// @interface DDRUMVitalEventRUMCITest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMVitalEventRUMCITest")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMCITest
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull testExecutionId;
		[Export ("testExecutionId")]
		string TestExecutionId { get; }
	}

	// @interface DDRUMVitalEventRUMConnectivity : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDRUMVitalEventRUMConnectivity")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMConnectivity
	{
		// @property (readonly, nonatomic, strong) DDRUMVitalEventRUMConnectivityCellular * _Nullable cellular;
		[NullAllowed, Export ("cellular", ArgumentSemantic.Strong)]
		DDRUMVitalEventRUMConnectivityCellular Cellular { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventRUMConnectivityEffectiveType effectiveType;
		[Export ("effectiveType")]
		DDRUMVitalEventRUMConnectivityEffectiveType EffectiveType { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable interfaces;
		[NullAllowed, Export ("interfaces", ArgumentSemantic.Copy)]
		NSNumber[] Interfaces { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventRUMConnectivityStatus status;
		[Export ("status")]
		DDRUMVitalEventRUMConnectivityStatus Status { get; }
	}

	// @interface DDRUMVitalEventRUMConnectivityCellular : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc38DDRUMVitalEventRUMConnectivityCellular")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMConnectivityCellular
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable carrierName;
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable technology;
		[NullAllowed, Export ("technology")]
		string Technology { get; }
	}

	// @interface DDRUMVitalEventRUMDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc24DDRUMVitalEventRUMDevice")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventRUMDeviceRUMDeviceType type;
		[Export ("type")]
		DDRUMVitalEventRUMDeviceRUMDeviceType Type { get; }
	}

	// @interface DDRUMVitalEventRUMEventAttributes : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMVitalEventRUMEventAttributes")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMEventAttributes
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull contextInfo;
		[Export ("contextInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ContextInfo { get; set; }
	}

	// @interface DDRUMVitalEventRUMOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDRUMVitalEventRUMOperatingSystem")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull versionMajor;
		[Export ("versionMajor")]
		string VersionMajor { get; }
	}

	// @interface DDRUMVitalEventRUMSyntheticsTest : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDRUMVitalEventRUMSyntheticsTest")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMSyntheticsTest
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable injected;
		[NullAllowed, Export ("injected", ArgumentSemantic.Strong)]
		NSNumber Injected { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull resultId;
		[Export ("resultId")]
		string ResultId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull testId;
		[Export ("testId")]
		string TestId { get; }
	}

	// @interface DDRUMVitalEventRUMUser : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMVitalEventRUMUser")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventRUMUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable anonymousId;
		[NullAllowed, Export ("anonymousId")]
		string AnonymousId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable id;
		[NullAllowed, Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull usrInfo;
		[Export ("usrInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; set; }
	}

	// @interface DDRUMVitalEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDRUMVitalEventSession")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventSession
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable hasReplay;
		[NullAllowed, Export ("hasReplay", ArgumentSemantic.Strong)]
		NSNumber HasReplay { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventSessionRUMSessionType type;
		[Export ("type")]
		DDRUMVitalEventSessionRUMSessionType Type { get; }
	}

	// @interface DDRUMVitalEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc19DDRUMVitalEventView")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable referrer;
		[NullAllowed, Export ("referrer")]
		string Referrer { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; set; }
	}

	// @interface DDRUMVitalEventVital : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDRUMVitalEventVital")]
	[DisableDefaultCtor]
	interface DDRUMVitalEventVital
	{
		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSNumber *> * _Nullable custom;
		[NullAllowed, Export ("custom", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSNumber> Custom { get; }

		// @property (nonatomic, readonly, copy) NSString * _Nullable vitalDescription;
		[NullAllowed, Export("vitalDescription")]
		string VitalDescription { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable duration;
		[NullAllowed, Export ("duration", ArgumentSemantic.Strong)]
		NSNumber Duration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) enum DDRUMVitalEventVitalVitalType type;
		[Export ("type")]
		DDRUMVitalEventVitalVitalType Type { get; }
	}

    interface IDDServerDateProvider {}

    // @protocol DDServerDateProvider
    [Protocol (Name = "_TtP11DatadogObjc20DDServerDateProvider_")]
	interface DDServerDateProvider
	{
		// @required -(void)synchronizeWithUpdate:(void (^ _Nonnull)(NSTimeInterval))update;
		[Abstract]
		[Export ("synchronizeWithUpdate:")]
		void Synchronize (Action<double> update);
	}

	// @interface DDSite : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc6DDSite")]
	[DisableDefaultCtor]
	interface DDSite
	{
		// +(DDSite * _Nonnull)us1 __attribute__((warn_unused_result("")));
		[Static]
		[Export ("us1")]
		DDSite US1 { get; }

		// +(DDSite * _Nonnull)us3 __attribute__((warn_unused_result("")));
		[Static]
		[Export ("us3")]
		DDSite US3 { get; }

		// +(DDSite * _Nonnull)us5 __attribute__((warn_unused_result("")));
		[Static]
		[Export ("us5")]
		DDSite US5 { get; }

		// +(DDSite * _Nonnull)eu1 __attribute__((warn_unused_result("")));
		[Static]
		[Export ("eu1")]
		DDSite EU1 { get; }

		// +(DDSite * _Nonnull)ap1 __attribute__((warn_unused_result("")));
		[Static]
		[Export ("ap1")]
		DDSite AP1 { get; }

		// +(DDSite * _Nonnull)us1_fed __attribute__((warn_unused_result("")));
		[Static]
		[Export ("us1_fed")]
		DDSite US1_Fed { get; }
	}

	// @interface DDTelemetryConfigurationEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDTelemetryConfigurationEvent")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEvent
	{
		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventAction * _Nullable action;
		[NullAllowed, Export ("action", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventApplication * _Nullable application;
		[NullAllowed, Export ("application", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventApplication Application { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable effectiveSampleRate;
		[NullAllowed, Export ("effectiveSampleRate", ArgumentSemantic.Strong)]
		NSNumber EffectiveSampleRate { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable experimentalFeatures;
		[NullAllowed, Export ("experimentalFeatures", ArgumentSemantic.Copy)]
		string[] ExperimentalFeatures { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull service;
		[Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDTelemetryConfigurationEventSource source;
		[Export ("source")]
		DDTelemetryConfigurationEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetry * _Nonnull telemetry;
		[Export ("telemetry", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetry Telemetry { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventView * _Nullable view;
		[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventView View { get; }
	}

	// @interface DDTelemetryConfigurationEventAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDTelemetryConfigurationEventAction")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventAction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryConfigurationEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc40DDTelemetryConfigurationEventApplication")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryConfigurationEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc31DDTelemetryConfigurationEventDD")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventDD
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }
	}

	// @interface DDTelemetryConfigurationEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc36DDTelemetryConfigurationEventSession")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryConfigurationEventTelemetry : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc38DDTelemetryConfigurationEventTelemetry")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetry
	{
		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetryConfiguration * _Nonnull configuration;
		[Export ("configuration", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetryConfiguration Configuration { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetryRUMTelemetryDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetryRUMTelemetryDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetryRUMTelemetryOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetryRUMTelemetryOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull telemetryInfo;
		[Export ("telemetryInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TelemetryInfo { get; set; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc51DDTelemetryConfigurationEventTelemetryConfiguration")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryConfiguration
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable actionNameAttribute;
		[NullAllowed, Export ("actionNameAttribute")]
		string ActionNameAttribute { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable allowFallbackToLocalStorage;
		[NullAllowed, Export ("allowFallbackToLocalStorage", ArgumentSemantic.Strong)]
		NSNumber AllowFallbackToLocalStorage { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable allowUntrustedEvents;
		[NullAllowed, Export ("allowUntrustedEvents", ArgumentSemantic.Strong)]
		NSNumber AllowUntrustedEvents { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable appHangThreshold;
		[NullAllowed, Export ("appHangThreshold", ArgumentSemantic.Strong)]
		NSNumber AppHangThreshold { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable backgroundTasksEnabled;
		[NullAllowed, Export ("backgroundTasksEnabled", ArgumentSemantic.Strong)]
		NSNumber BackgroundTasksEnabled { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable batchProcessingLevel;
		[NullAllowed, Export ("batchProcessingLevel", ArgumentSemantic.Strong)]
		NSNumber BatchProcessingLevel { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable batchSize;
		[NullAllowed, Export ("batchSize", ArgumentSemantic.Strong)]
		NSNumber BatchSize { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable batchUploadFrequency;
		[NullAllowed, Export ("batchUploadFrequency", ArgumentSemantic.Strong)]
		NSNumber BatchUploadFrequency { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable compressIntakeRequests;
		[NullAllowed, Export ("compressIntakeRequests", ArgumentSemantic.Strong)]
		NSNumber CompressIntakeRequests { get; }

		// @property (copy, nonatomic) NSString * _Nullable dartVersion;
		[NullAllowed, Export ("dartVersion")]
		string DartVersion { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable defaultPrivacyLevel;
		[NullAllowed, Export ("defaultPrivacyLevel")]
		string DefaultPrivacyLevel { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable enablePrivacyForActionName;
		[NullAllowed, Export ("enablePrivacyForActionName", ArgumentSemantic.Strong)]
		NSNumber EnablePrivacyForActionName { get; set; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetryConfigurationForwardConsoleLogs * _Nullable forwardConsoleLogs;
		[NullAllowed, Export ("forwardConsoleLogs", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetryConfigurationForwardConsoleLogs ForwardConsoleLogs { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable forwardErrorsToLogs;
		[NullAllowed, Export ("forwardErrorsToLogs", ArgumentSemantic.Strong)]
		NSNumber ForwardErrorsToLogs { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryConfigurationEventTelemetryConfigurationForwardReports * _Nullable forwardReports;
		[NullAllowed, Export ("forwardReports", ArgumentSemantic.Strong)]
		DDTelemetryConfigurationEventTelemetryConfigurationForwardReports ForwardReports { get; }

		// @property (copy, nonatomic) NSString * _Nullable imagePrivacyLevel;
		[NullAllowed, Export ("imagePrivacyLevel")]
		string ImagePrivacyLevel { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable initializationType;
		[NullAllowed, Export ("initializationType")]
		string InitializationType { get; set; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable invTimeThresholdMs;
		[NullAllowed, Export("invTimeThresholdMs", ArgumentSemantic.Strong)]
		NSNumber InvTimeThresholdMs { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable isMainProcess;
		[NullAllowed, Export("isMainProcess", ArgumentSemantic.Strong)]
		NSNumber IsMainProcess { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable mobileVitalsUpdatePeriod;
		[NullAllowed, Export ("mobileVitalsUpdatePeriod", ArgumentSemantic.Strong)]
		NSNumber MobileVitalsUpdatePeriod { get; set; }

		// @property (copy, nonatomic) NSArray<DDTelemetryConfigurationEventTelemetryConfigurationPlugins *> * _Nullable plugins;
		[NullAllowed, Export ("plugins", ArgumentSemantic.Copy)]
		DDTelemetryConfigurationEventTelemetryConfigurationPlugins[] Plugins { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable premiumSampleRate;
		[NullAllowed, Export ("premiumSampleRate", ArgumentSemantic.Strong)]
		NSNumber PremiumSampleRate { get; }

		// @property (copy, nonatomic) NSString * _Nullable reactNativeVersion;
		[NullAllowed, Export ("reactNativeVersion")]
		string ReactNativeVersion { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable reactVersion;
		[NullAllowed, Export ("reactVersion")]
		string ReactVersion { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable replaySampleRate;
		[NullAllowed, Export ("replaySampleRate", ArgumentSemantic.Strong)]
		NSNumber ReplaySampleRate { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable selectedTracingPropagators;
		[NullAllowed, Export ("selectedTracingPropagators", ArgumentSemantic.Copy)]
		NSNumber[] SelectedTracingPropagators { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable sendLogsAfterSessionExpiration;
		[NullAllowed, Export ("sendLogsAfterSessionExpiration", ArgumentSemantic.Strong)]
		NSNumber SendLogsAfterSessionExpiration { get; set; }

		// @property (nonatomic, readonly) enum DDTelemetryConfigurationEventTelemetryConfigurationSessionPersistence sessionPersistence;
		[Export("sessionPersistence")]
		DDTelemetryConfigurationEventTelemetryConfigurationSessionPersistence SessionPersistence { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable sessionReplaySampleRate;
		[NullAllowed, Export("sessionReplaySampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionReplaySampleRate { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable sessionSampleRate;
		[NullAllowed, Export ("sessionSampleRate", ArgumentSemantic.Strong)]
		NSNumber SessionSampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable silentMultipleInit;
		[NullAllowed, Export ("silentMultipleInit", ArgumentSemantic.Strong)]
		NSNumber SilentMultipleInit { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable startRecordingImmediately;
		[NullAllowed, Export ("startRecordingImmediately", ArgumentSemantic.Strong)]
		NSNumber StartRecordingImmediately { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable startSessionReplayRecordingManually;
		[NullAllowed, Export ("startSessionReplayRecordingManually", ArgumentSemantic.Strong)]
		NSNumber StartSessionReplayRecordingManually { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable storeContextsAcrossPages;
		[NullAllowed, Export ("storeContextsAcrossPages", ArgumentSemantic.Strong)]
		NSNumber StoreContextsAcrossPages { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable telemetryConfigurationSampleRate;
		[NullAllowed, Export ("telemetryConfigurationSampleRate", ArgumentSemantic.Strong)]
		NSNumber TelemetryConfigurationSampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable telemetrySampleRate;
		[NullAllowed, Export ("telemetrySampleRate", ArgumentSemantic.Strong)]
		NSNumber TelemetrySampleRate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable telemetryUsageSampleRate;
		[NullAllowed, Export ("telemetryUsageSampleRate", ArgumentSemantic.Strong)]
		NSNumber TelemetryUsageSampleRate { get; }

		// @property (copy, nonatomic) NSString * _Nullable textAndInputPrivacyLevel;
		[NullAllowed, Export ("textAndInputPrivacyLevel")]
		string TextAndInputPrivacyLevel { get; set; }

		// @property (nonatomic, readonly, strong) NSNumber * _Nullable tnsTimeThresholdMs;
		[NullAllowed, Export("tnsTimeThresholdMs", ArgumentSemantic.Strong)]
		NSNumber TnsTimeThresholdMs { get; }

		// @property (copy, nonatomic) NSString * _Nullable touchPrivacyLevel;
		[NullAllowed, Export("touchPrivacyLevel")]
		string TouchPrivacyLevel { get; set; }

		// @property (nonatomic) enum DDTelemetryConfigurationEventTelemetryConfigurationTraceContextInjection traceContextInjection;
		[Export ("traceContextInjection", ArgumentSemantic.Assign)]
		DDTelemetryConfigurationEventTelemetryConfigurationTraceContextInjection TraceContextInjection { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable traceSampleRate;
		[NullAllowed, Export ("traceSampleRate", ArgumentSemantic.Strong)]
		NSNumber TraceSampleRate { get; }

		// @property (copy, nonatomic) NSString * _Nullable tracerApi;
		[NullAllowed, Export ("tracerApi")]
		string TracerApi { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable tracerApiVersion;
		[NullAllowed, Export ("tracerApiVersion")]
		string TracerApiVersion { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackAnonymousUser;
		[NullAllowed, Export("trackAnonymousUser", ArgumentSemantic.Strong)]
		NSNumber TrackAnonymousUser { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackBackgroundEvents;
		[NullAllowed, Export("trackBackgroundEvents", ArgumentSemantic.Strong)]
		NSNumber TrackBackgroundEvents { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackCrossPlatformLongTasks;
		[NullAllowed, Export ("trackCrossPlatformLongTasks", ArgumentSemantic.Strong)]
		NSNumber TrackCrossPlatformLongTasks { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackErrors;
		[NullAllowed, Export ("trackErrors", ArgumentSemantic.Strong)]
		NSNumber TrackErrors { get; set; }

		// @property (nonatomic, readonly, copy) NSArray<NSNumber *> * _Nullable trackFeatureFlagsForEvents;
		[NullAllowed, Export("trackFeatureFlagsForEvents", ArgumentSemantic.Copy)]
		NSNumber[] TrackFeatureFlagsForEvents { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackFlutterPerformance;
		[NullAllowed, Export("trackFlutterPerformance", ArgumentSemantic.Strong)]
		NSNumber TrackFlutterPerformance { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackFrustrations;
		[NullAllowed, Export ("trackFrustrations", ArgumentSemantic.Strong)]
		NSNumber TrackFrustrations { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackInteractions;
		[NullAllowed, Export ("trackInteractions", ArgumentSemantic.Strong)]
		NSNumber TrackInteractions { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackLongTask;
		[NullAllowed, Export ("trackLongTask", ArgumentSemantic.Strong)]
		NSNumber TrackLongTask { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackNativeErrors;
		[NullAllowed, Export ("trackNativeErrors", ArgumentSemantic.Strong)]
		NSNumber TrackNativeErrors { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackNativeLongTasks;
		[NullAllowed, Export ("trackNativeLongTasks", ArgumentSemantic.Strong)]
		NSNumber TrackNativeLongTasks { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackNativeViews;
		[NullAllowed, Export ("trackNativeViews", ArgumentSemantic.Strong)]
		NSNumber TrackNativeViews { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackNetworkRequests;
		[NullAllowed, Export ("trackNetworkRequests", ArgumentSemantic.Strong)]
		NSNumber TrackNetworkRequests { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackResources;
		[NullAllowed, Export ("trackResources", ArgumentSemantic.Strong)]
		NSNumber TrackResources { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable trackSessionAcrossSubdomains;
		[NullAllowed, Export ("trackSessionAcrossSubdomains", ArgumentSemantic.Strong)]
		NSNumber TrackSessionAcrossSubdomains { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackUserInteractions;
		[NullAllowed, Export ("trackUserInteractions", ArgumentSemantic.Strong)]
		NSNumber TrackUserInteractions { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable trackViewsManually;
		[NullAllowed, Export ("trackViewsManually", ArgumentSemantic.Strong)]
		NSNumber TrackViewsManually { get; set; }

		// @property (readonly, nonatomic) enum DDTelemetryConfigurationEventTelemetryConfigurationTrackingConsent trackingConsent;
		[Export ("trackingConsent")]
		DDTelemetryConfigurationEventTelemetryConfigurationTrackingConsent TrackingConsent { get; }

		// @property (copy, nonatomic) NSString * _Nullable unityVersion;
		[NullAllowed, Export ("unityVersion")]
		string UnityVersion { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useAllowedTracingOrigins;
		[NullAllowed, Export ("useAllowedTracingOrigins", ArgumentSemantic.Strong)]
		NSNumber UseAllowedTracingOrigins { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useAllowedTracingUrls;
		[NullAllowed, Export ("useAllowedTracingUrls", ArgumentSemantic.Strong)]
		NSNumber UseAllowedTracingUrls { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useBeforeSend;
		[NullAllowed, Export ("useBeforeSend", ArgumentSemantic.Strong)]
		NSNumber UseBeforeSend { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useCrossSiteSessionCookie;
		[NullAllowed, Export ("useCrossSiteSessionCookie", ArgumentSemantic.Strong)]
		NSNumber UseCrossSiteSessionCookie { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useExcludedActivityUrls;
		[NullAllowed, Export ("useExcludedActivityUrls", ArgumentSemantic.Strong)]
		NSNumber UseExcludedActivityUrls { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable useFirstPartyHosts;
		[NullAllowed, Export ("useFirstPartyHosts", ArgumentSemantic.Strong)]
		NSNumber UseFirstPartyHosts { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useLocalEncryption;
		[NullAllowed, Export ("useLocalEncryption", ArgumentSemantic.Strong)]
		NSNumber UseLocalEncryption { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable usePartitionedCrossSiteSessionCookie;
		[NullAllowed, Export ("usePartitionedCrossSiteSessionCookie", ArgumentSemantic.Strong)]
		NSNumber UsePartitionedCrossSiteSessionCookie { get; }

		// @property (nonatomic, strong) NSNumber * _Nullable usePciIntake;
		[NullAllowed, Export ("usePciIntake", ArgumentSemantic.Strong)]
		NSNumber UsePCIIntake { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable useProxy;
		[NullAllowed, Export ("useProxy", ArgumentSemantic.Strong)]
		NSNumber UseProxy { get; set; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useSecureSessionCookie;
		[NullAllowed, Export ("useSecureSessionCookie", ArgumentSemantic.Strong)]
		NSNumber UseSecureSessionCookie { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useTracing;
		[NullAllowed, Export ("useTracing", ArgumentSemantic.Strong)]
		NSNumber UseTracing { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable useWorkerUrl;
		[NullAllowed, Export ("useWorkerUrl", ArgumentSemantic.Strong)]
		NSNumber UseWorkerUrl { get; }

		// @property (readonly, nonatomic) enum DDTelemetryConfigurationEventTelemetryConfigurationViewTrackingStrategy viewTrackingStrategy;
		[Export ("viewTrackingStrategy")]
		DDTelemetryConfigurationEventTelemetryConfigurationViewTrackingStrategy ViewTrackingStrategy { get; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryConfigurationForwardConsoleLogs : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc69DDTelemetryConfigurationEventTelemetryConfigurationForwardConsoleLogs")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryConfigurationForwardConsoleLogs
	{
		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable stringsArray;
		[NullAllowed, Export ("stringsArray", ArgumentSemantic.Copy)]
		string[] StringsArray { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryConfigurationForwardReports : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc65DDTelemetryConfigurationEventTelemetryConfigurationForwardReports")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryConfigurationForwardReports
	{
		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable stringsArray;
		[NullAllowed, Export ("stringsArray", ArgumentSemantic.Copy)]
		string[] StringsArray { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryConfigurationPlugins : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc58DDTelemetryConfigurationEventTelemetryConfigurationPlugins")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryConfigurationPlugins
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull pluginsInfo;
		[Export ("pluginsInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PluginsInfo { get; set; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryRUMTelemetryDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc56DDTelemetryConfigurationEventTelemetryRUMTelemetryDevice")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryRUMTelemetryDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }
	}

	// @interface DDTelemetryConfigurationEventTelemetryRUMTelemetryOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc65DDTelemetryConfigurationEventTelemetryRUMTelemetryOperatingSystem")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventTelemetryRUMTelemetryOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }
	}

	// @interface DDTelemetryConfigurationEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc33DDTelemetryConfigurationEventView")]
	[DisableDefaultCtor]
	interface DDTelemetryConfigurationEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryDebugEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDTelemetryDebugEvent")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEvent
	{
		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventAction * _Nullable action;
		[NullAllowed, Export ("action", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventApplication * _Nullable application;
		[NullAllowed, Export ("application", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventApplication Application { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable effectiveSampleRate;
		[NullAllowed, Export ("effectiveSampleRate", ArgumentSemantic.Strong)]
		NSNumber EffectiveSampleRate { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable experimentalFeatures;
		[NullAllowed, Export ("experimentalFeatures", ArgumentSemantic.Copy)]
		string[] ExperimentalFeatures { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull service;
		[Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDTelemetryDebugEventSource source;
		[Export ("source")]
		DDTelemetryDebugEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventTelemetry * _Nonnull telemetry;
		[Export ("telemetry", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventTelemetry Telemetry { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventView * _Nullable view;
		[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventView View { get; }
	}

	// @interface DDTelemetryDebugEventAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDTelemetryDebugEventAction")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventAction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryDebugEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDTelemetryDebugEventApplication")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryDebugEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDTelemetryDebugEventDD")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventDD
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }
	}

	// @interface DDTelemetryDebugEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDTelemetryDebugEventSession")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryDebugEventTelemetry : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDTelemetryDebugEventTelemetry")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventTelemetry
	{
		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventTelemetryRUMTelemetryDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventTelemetryRUMTelemetryDevice Device { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryDebugEventTelemetryRUMTelemetryOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDTelemetryDebugEventTelemetryRUMTelemetryOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull status;
		[Export ("status")]
		string Status { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable type;
		[NullAllowed, Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull telemetryInfo;
		[Export ("telemetryInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TelemetryInfo { get; set; }
	}

	// @interface DDTelemetryDebugEventTelemetryRUMTelemetryDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc48DDTelemetryDebugEventTelemetryRUMTelemetryDevice")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventTelemetryRUMTelemetryDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }
	}

	// @interface DDTelemetryDebugEventTelemetryRUMTelemetryOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc57DDTelemetryDebugEventTelemetryRUMTelemetryOperatingSystem")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventTelemetryRUMTelemetryOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }
	}

	// @interface DDTelemetryDebugEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDTelemetryDebugEventView")]
	[DisableDefaultCtor]
	interface DDTelemetryDebugEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryErrorEvent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc21DDTelemetryErrorEvent")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEvent
	{
		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventDD * _Nonnull dd;
		[Export ("dd", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventDD DD { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventAction * _Nullable action;
		[NullAllowed, Export ("action", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventAction Action { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventApplication * _Nullable application;
		[NullAllowed, Export ("application", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventApplication Application { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSNumber Date { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable effectiveSampleRate;
		[NullAllowed, Export ("effectiveSampleRate", ArgumentSemantic.Strong)]
		NSNumber EffectiveSampleRate { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable experimentalFeatures;
		[NullAllowed, Export ("experimentalFeatures", ArgumentSemantic.Copy)]
		string[] ExperimentalFeatures { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull service;
		[Export ("service")]
		string Service { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventSession Session { get; }

		// @property (readonly, nonatomic) enum DDTelemetryErrorEventSource source;
		[Export ("source")]
		DDTelemetryErrorEventSource Source { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventTelemetry * _Nonnull telemetry;
		[Export ("telemetry", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventTelemetry Telemetry { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventView * _Nullable view;
		[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventView View { get; }
	}

	// @interface DDTelemetryErrorEventAction : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDTelemetryErrorEventAction")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventAction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryErrorEventApplication : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc32DDTelemetryErrorEventApplication")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventApplication
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryErrorEventDD : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDTelemetryErrorEventDD")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventDD
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nonnull formatVersion;
		[Export ("formatVersion", ArgumentSemantic.Strong)]
		NSNumber FormatVersion { get; }
	}

	// @interface DDTelemetryErrorEventSession : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc28DDTelemetryErrorEventSession")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTelemetryErrorEventTelemetry : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc30DDTelemetryErrorEventTelemetry")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventTelemetry
	{
		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventTelemetryRUMTelemetryDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventTelemetryRUMTelemetryDevice Device { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventTelemetryError * _Nullable error;
		[NullAllowed, Export ("error", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventTelemetryError Error { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic, strong) DDTelemetryErrorEventTelemetryRUMTelemetryOperatingSystem * _Nullable os;
		[NullAllowed, Export ("os", ArgumentSemantic.Strong)]
		DDTelemetryErrorEventTelemetryRUMTelemetryOperatingSystem OS { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull status;
		[Export ("status")]
		string Status { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable type;
		[NullAllowed, Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull telemetryInfo;
		[Export ("telemetryInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TelemetryInfo { get; set; }
	}

	// @interface DDTelemetryErrorEventTelemetryError : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc35DDTelemetryErrorEventTelemetryError")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventTelemetryError
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable kind;
		[NullAllowed, Export ("kind")]
		string Kind { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable stack;
		[NullAllowed, Export ("stack")]
		string Stack { get; }
	}

	// @interface DDTelemetryErrorEventTelemetryRUMTelemetryDevice : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc48DDTelemetryErrorEventTelemetryRUMTelemetryDevice")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventTelemetryRUMTelemetryDevice
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable architecture;
		[NullAllowed, Export ("architecture")]
		string Architecture { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable brand;
		[NullAllowed, Export ("brand")]
		string Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable model;
		[NullAllowed, Export ("model")]
		string Model { get; }
	}

	// @interface DDTelemetryErrorEventTelemetryRUMTelemetryOperatingSystem : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc57DDTelemetryErrorEventTelemetryRUMTelemetryOperatingSystem")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventTelemetryRUMTelemetryOperatingSystem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable build;
		[NullAllowed, Export ("build")]
		string Build { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }
	}

	// @interface DDTelemetryErrorEventView : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDTelemetryErrorEventView")]
	[DisableDefaultCtor]
	interface DDTelemetryErrorEventView
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }
	}

	// @interface DDTrace : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc7DDTrace")]
	interface DDTrace
	{
		// +(void)enableWith:(DDTraceConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("enableWith:")]
		void Enable (DDTraceConfiguration configuration);
	}

	// @interface DDTraceConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc20DDTraceConfiguration")]
	interface DDTraceConfiguration
	{
		// @property (nonatomic) float sampleRate;
		[Export ("sampleRate")]
		float SampleRate { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable service;
		[NullAllowed, Export ("service")]
		string Service { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable tags;
		[NullAllowed, Export ("tags", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Tags { get; set; }

		// -(void)setURLSessionTracking:(DDTraceURLSessionTracking * _Nonnull)tracking;
		[Export ("setURLSessionTracking:")]
		void SetURLSessionTracking (DDTraceURLSessionTracking tracking);

		// @property (nonatomic) BOOL bundleWithRumEnabled;
		[Export ("bundleWithRumEnabled")]
		bool BundleWithRumEnabled { get; set; }

		// @property (nonatomic) BOOL networkInfoEnabled;
		[Export ("networkInfoEnabled")]
		bool NetworkInfoEnabled { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable customEndpoint;
		[NullAllowed, Export ("customEndpoint", ArgumentSemantic.Copy)]
		NSUrl CustomEndpoint { get; set; }
	}

	// @interface DDTraceFirstPartyHostsTracing : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc29DDTraceFirstPartyHostsTracing")]
	[DisableDefaultCtor]
	interface DDTraceFirstPartyHostsTracing
	{
		// -(instancetype _Nonnull)initWithHostsWithHeaderTypes:(NSDictionary<NSString *,NSSet<DDTracingHeaderType *> *> * _Nonnull)hostsWithHeaderTypes __attribute__((objc_designated_initializer));
		[Export ("initWithHostsWithHeaderTypes:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSDictionary<NSString, NSSet<DDTracingHeaderType>> hostsWithHeaderTypes);

		// -(instancetype _Nonnull)initWithHostsWithHeaderTypes:(NSDictionary<NSString *,NSSet<DDTracingHeaderType *> *> * _Nonnull)hostsWithHeaderTypes sampleRate:(float)sampleRate __attribute__((objc_designated_initializer));
		[Export ("initWithHostsWithHeaderTypes:sampleRate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSDictionary<NSString, NSSet<DDTracingHeaderType>> hostsWithHeaderTypes, float sampleRate);

		// -(instancetype _Nonnull)initWithHosts:(NSSet<NSString *> * _Nonnull)hosts __attribute__((objc_designated_initializer));
		[Export ("initWithHosts:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSString> hosts);

		// -(instancetype _Nonnull)initWithHosts:(NSSet<NSString *> * _Nonnull)hosts sampleRate:(float)sampleRate __attribute__((objc_designated_initializer));
		[Export ("initWithHosts:sampleRate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSString> hosts, float sampleRate);
	}

	// @interface DDTraceSamplingStrategy : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc23DDTraceSamplingStrategy")]
	[DisableDefaultCtor]
	interface DDTraceSamplingStrategy
	{
		// +(DDTraceSamplingStrategy * _Nonnull)headBased __attribute__((warn_unused_result("")));
		[Static]
		[Export ("headBased")]
		DDTraceSamplingStrategy HeadBased { get; }

		// +(DDTraceSamplingStrategy * _Nonnull)customWithSampleRate:(float)sampleRate __attribute__((warn_unused_result("")));
		[Static]
		[Export ("customWithSampleRate:")]
		DDTraceSamplingStrategy Custom (float sampleRate);
	}

	// @interface DDTraceURLSessionTracking : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc25DDTraceURLSessionTracking")]
	[DisableDefaultCtor]
	interface DDTraceURLSessionTracking
	{
		// -(instancetype _Nonnull)initWithFirstPartyHostsTracing:(DDTraceFirstPartyHostsTracing * _Nonnull)firstPartyHostsTracing __attribute__((objc_designated_initializer));
		[Export ("initWithFirstPartyHostsTracing:")]
		[DesignatedInitializer]
		NativeHandle Constructor (DDTraceFirstPartyHostsTracing firstPartyHostsTracing);

		// -(void)setFirstPartyHostsTracing:(DDTraceFirstPartyHostsTracing * _Nonnull)firstPartyHostsTracing;
		[Export ("setFirstPartyHostsTracing:")]
		void SetFirstPartyHostsTracing (DDTraceFirstPartyHostsTracing firstPartyHostsTracing);
	}

	// @protocol OTTracer
	[Protocol (Name = "_TtP11DatadogObjc8OTTracer_")]
	interface OTTracer
	{
		// @required -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("startSpan:")]
		IOTSpan StartSpan (string operationName);

		// @required -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName tags:(NSDictionary * _Nullable)tags __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("startSpan:tags:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] NSDictionary tags);

		// @required -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("startSpan:childOf:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent);

		// @required -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent tags:(NSDictionary * _Nullable)tags __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("startSpan:childOf:tags:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent, [NullAllowed] NSDictionary tags);

		// @required -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent tags:(NSDictionary * _Nullable)tags startTime:(NSDate * _Nullable)startTime __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("startSpan:childOf:tags:startTime:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent, [NullAllowed] NSDictionary tags, [NullAllowed] NSDate startTime);

		// @required -(BOOL)inject:(id<OTSpanContext> _Nonnull)spanContext format:(NSString * _Nonnull)format carrier:(id _Nonnull)carrier error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("inject:format:carrier:error:")]
		bool Inject (IOTSpanContext spanContext, string format, NSObject carrier, [NullAllowed] out NSError error);

		// @required -(BOOL)extractWithFormat:(NSString * _Nonnull)format carrier:(id _Nonnull)carrier error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("extractWithFormat:carrier:error:")]
		bool Extract(string format, NSObject carrier, [NullAllowed] out NSError error);
	}

	interface IOTTracer { }
	interface IOTSpan { }
	interface IOTSpanContext { }

#pragma warning disable CS0108
	// @interface DDTracer : NSObject <OTTracer>
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc8DDTracer")]
	[DisableDefaultCtor]
	interface DDTracer : OTTracer
	{
		// +(id<OTTracer> _Nonnull)shared __attribute__((warn_unused_result("")));
		[Static]
		[Export ("shared")]
		IOTTracer Shared { get; }

		// -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName __attribute__((warn_unused_result("")));
		[Export ("startSpan:")]
		IOTSpan StartSpan (string operationName);

		// -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName tags:(NSDictionary * _Nullable)tags __attribute__((warn_unused_result("")));
		[Export ("startSpan:tags:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] NSDictionary tags);

		// -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent __attribute__((warn_unused_result("")));
		[Export ("startSpan:childOf:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent);

		// -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent tags:(NSDictionary * _Nullable)tags __attribute__((warn_unused_result("")));
		[Export ("startSpan:childOf:tags:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent, [NullAllowed] NSDictionary tags);

		// -(id<OTSpan> _Nonnull)startSpan:(NSString * _Nonnull)operationName childOf:(id<OTSpanContext> _Nullable)parent tags:(NSDictionary * _Nullable)tags startTime:(NSDate * _Nullable)startTime __attribute__((warn_unused_result("")));
		[Export ("startSpan:childOf:tags:startTime:")]
		IOTSpan StartSpan (string operationName, [NullAllowed] IOTSpanContext parent, [NullAllowed] NSDictionary tags, [NullAllowed] NSDate startTime);

		// -(BOOL)inject:(id<OTSpanContext> _Nonnull)spanContext format:(NSString * _Nonnull)format carrier:(id _Nonnull)carrier error:(NSError * _Nullable * _Nullable)error;
		[Export ("inject:format:carrier:error:")]
		bool Inject (IOTSpanContext spanContext, string format, NSObject carrier, [NullAllowed] out NSError error);

		// removed Extract() due to comment in Swift code:
		// TODO: RUMM-385 - we don't need to support it now
	}
#pragma warning restore CS0108

	// @interface DDTracingHeaderType : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc19DDTracingHeaderType")]
	[DisableDefaultCtor]
	interface DDTracingHeaderType : INativeObject
	{
		// @property (readonly, nonatomic, strong, class) DDTracingHeaderType * _Nonnull datadog;
		[Static]
		[Export ("datadog", ArgumentSemantic.Strong)]
		DDTracingHeaderType Datadog { get; }

		// @property (readonly, nonatomic, strong, class) DDTracingHeaderType * _Nonnull b3multi;
		[Static]
		[Export ("b3multi", ArgumentSemantic.Strong)]
		DDTracingHeaderType B3Multi { get; }

		// @property (readonly, nonatomic, strong, class) DDTracingHeaderType * _Nonnull b3;
		[Static]
		[Export ("b3", ArgumentSemantic.Strong)]
		DDTracingHeaderType B3 { get; }

		// @property (readonly, nonatomic, strong, class) DDTracingHeaderType * _Nonnull tracecontext;
		[Static]
		[Export ("tracecontext", ArgumentSemantic.Strong)]
		DDTracingHeaderType TraceContext { get; }
	}

	// @interface DDTrackingConsent : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc17DDTrackingConsent")]
	[DisableDefaultCtor]
	interface DDTrackingConsent
	{
		// +(DDTrackingConsent * _Nonnull)granted __attribute__((warn_unused_result("")));
		[Static]
		[Export ("granted")]
		DDTrackingConsent Granted { get; }

		// +(DDTrackingConsent * _Nonnull)notGranted __attribute__((warn_unused_result("")));
		[Static]
		[Export ("notGranted")]
		DDTrackingConsent NotGranted { get; }

		// +(DDTrackingConsent * _Nonnull)pending __attribute__((warn_unused_result("")));
		[Static]
		[Export ("pending")]
		DDTrackingConsent Pending { get; }
	}

	// @protocol DDUIPressRUMActionsPredicate
	[Protocol (Name = "_TtP11DatadogObjc28DDUIPressRUMActionsPredicate_")]
	interface DDUIPressRUMActionsPredicate
	{
		// @required -(DDRUMAction * _Nullable)rumActionWithPress:(enum UIPressType)type targetView:(UIView * _Nonnull)targetView __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("rumActionWithPress:targetView:")]
		[return: NullAllowed]
		DDRUMAction RumAction (UIPressType type, UIView targetView);
	}

	// @interface DDURLSessionInstrumentation : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc27DDURLSessionInstrumentation")]
	interface DDURLSessionInstrumentation
	{
		// +(void)enableWithConfiguration:(DDURLSessionInstrumentationConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("enableWithConfiguration:")]
		void Enable(DDURLSessionInstrumentationConfiguration configuration);

		// +(void)disableWithDelegateClass:(Class<NSURLSessionDataDelegate> _Nonnull)delegateClass;
		[Static]
		[Internal]
		[Export ("disableWithDelegateClass:")]
		void Disable(Class delegateClass);
	}

	// @interface DDURLSessionInstrumentationConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc40DDURLSessionInstrumentationConfiguration")]
	[DisableDefaultCtor]
	interface DDURLSessionInstrumentationConfiguration
	{
		// -(instancetype _Nonnull)initWithDelegateClass:(Class<NSURLSessionDataDelegate> _Nonnull)delegateClass __attribute__((objc_designated_initializer));
		[Export ("initWithDelegateClass:")]
		[DesignatedInitializer]
		NativeHandle Constructor (INSUrlSessionDataDelegate delegateClass);

		// -(void)setFirstPartyHostsTracing:(DDURLSessionInstrumentationFirstPartyHostsTracing * _Nonnull)firstPartyHostsTracing;
		[Export ("setFirstPartyHostsTracing:")]
		void SetFirstPartyHostsTracing (DDURLSessionInstrumentationFirstPartyHostsTracing firstPartyHostsTracing);

		// @property (nonatomic) Class<NSURLSessionDataDelegate> _Nonnull delegateClass;
		[Export ("delegateClass", ArgumentSemantic.Assign)]
		INSUrlSessionDataDelegate DelegateClass { get; set; }
	}

	// @interface DDURLSessionInstrumentationFirstPartyHostsTracing : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc49DDURLSessionInstrumentationFirstPartyHostsTracing")]
	[DisableDefaultCtor]
	interface DDURLSessionInstrumentationFirstPartyHostsTracing
	{
		// -(instancetype _Nonnull)initWithHostsWithHeaderTypes:(NSDictionary<NSString *,NSSet<DDTracingHeaderType *> *> * _Nonnull)hostsWithHeaderTypes __attribute__((objc_designated_initializer));
		[Export ("initWithHostsWithHeaderTypes:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSDictionary<NSString, NSSet<DDTracingHeaderType>> hostsWithHeaderTypes);

		// -(instancetype _Nonnull)initWithHosts:(NSSet<NSString *> * _Nonnull)hosts __attribute__((objc_designated_initializer));
		[Export ("initWithHosts:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSString> hosts);
	}

	// @interface DDW3CHTTPHeadersWriter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc22DDW3CHTTPHeadersWriter")]
	[DisableDefaultCtor]
	interface DDW3CHTTPHeadersWriter
	{
		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull traceHeaderFields;
		[Export ("traceHeaderFields", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> TraceHeaderFields { get; }

		// removed deprecated constructors causing build errors

		// -(instancetype _Nonnull)initWithSamplingStrategy:(DDTraceSamplingStrategy * _Nonnull)samplingStrategy traceContextInjection:(enum DDTraceContextInjection)traceContextInjection __attribute__((objc_designated_initializer));
		[Export ("initWithSamplingStrategy:traceContextInjection:")]
		[DesignatedInitializer]
		NativeHandle Constructor (DDTraceSamplingStrategy samplingStrategy, DDTraceContextInjection traceContextInjection);
	}

	// @interface OT : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11DatadogObjc2OT")]
	interface OT
	{
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull formatTextMap;
		[Static]
		[Export ("formatTextMap")]
		string FormatTextMap { get; }
	}

	// @protocol OTSpan
	[Protocol (Name = "_TtP11DatadogObjc6OTSpan_")]
	interface OTSpan
	{
		// @required @property (readonly, nonatomic, strong) id<OTSpanContext> _Nonnull context;
		[Abstract]
		[Export ("context", ArgumentSemantic.Strong)]
		IOTSpanContext Context { get; }

		// @required @property (readonly, nonatomic, strong) id<OTTracer> _Nonnull tracer;
		[Abstract]
		[Export ("tracer", ArgumentSemantic.Strong)]
		IOTTracer Tracer { get; }

		// @required -(void)setOperationName:(NSString * _Nonnull)operationName;
		[Abstract]
		[Export ("setOperationName:")]
		void SetOperationName (string operationName);

		// @required -(void)setTag:(NSString * _Nonnull)key value:(NSString * _Nonnull)value;
		[Abstract]
		[Export ("setTag:value:")]
		void SetTag (string key, string value);

		// @required -(void)setTag:(NSString * _Nonnull)key numberValue:(NSNumber * _Nonnull)numberValue;
		[Abstract]
		[Export ("setTag:numberValue:")]
		void SetTag (string key, NSNumber numberValue);

		// @required -(void)setTag:(NSString * _Nonnull)key boolValue:(BOOL)boolValue;
		[Abstract]
		[Export ("setTag:boolValue:")]
		void SetTag (string key, bool boolValue);

		// @required -(void)log:(NSDictionary<NSString *,NSObject *> * _Nonnull)fields;
		[Abstract]
		[Export ("log:")]
		void Log (NSDictionary<NSString, NSObject> fields);

		// @required -(void)log:(NSDictionary<NSString *,NSObject *> * _Nonnull)fields timestamp:(NSDate * _Nullable)timestamp;
		[Abstract]
		[Export ("log:timestamp:")]
		void Log (NSDictionary<NSString, NSObject> fields, [NullAllowed] NSDate timestamp);

		// @required -(id<OTSpan> _Nonnull)setBaggageItem:(NSString * _Nonnull)key value:(NSString * _Nonnull)value __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("setBaggageItem:value:")]
		IOTSpan SetBaggageItem (string key, string value);

		// @required -(NSString * _Nullable)getBaggageItem:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("getBaggageItem:")]
		[return: NullAllowed]
		string GetBaggageItem (string key);

		// @required -(void)setError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("setError:")]
		void SetError (NSError error);

		// @required -(void)setErrorWithKind:(NSString * _Nonnull)kind message:(NSString * _Nonnull)message stack:(NSString * _Nullable)stack;
		[Abstract]
		[Export ("setErrorWithKind:message:stack:")]
		void SetError(string kind, string message, [NullAllowed] string stack);

		// @required -(void)finish;
		[Abstract]
		[Export ("finish")]
		void Finish ();

		// @required -(void)finishWithTime:(NSDate * _Nullable)finishTime;
		[Abstract]
		[Export ("finishWithTime:")]
		void Finish([NullAllowed] NSDate finishTime);

		// @required -(id<OTSpan> _Nonnull)setActive;
		[Abstract]
		[Export ("setActive")]
		IOTSpan SetActive();
	}

	// @protocol OTSpanContext
	[Protocol (Name = "_TtP11DatadogObjc13OTSpanContext_")]
	interface OTSpanContext
	{
		// @required -(void)forEachBaggageItem:(BOOL (^ _Nonnull)(NSString * _Nonnull, NSString * _Nonnull))callback;
		[Abstract]
		[Export ("forEachBaggageItem:")]
		void ForEachBaggageItem (Func<NSString, NSString, bool> callback);
	}

	// remove deprecated DatadogURLSessionDelegate class - causes multiple selector registration errors anyway

	// remove deprecated URLSessionDelegateProviding protocol - same reason as above
}
