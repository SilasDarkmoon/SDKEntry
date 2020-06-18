//
//  SubSDK.m
//  Unity-iPhone
//
//  Created by admin on 2020/6/18.
//
#import "SubSDK.h"
#import "UnityAppController.h"

NSMutableArray* SubSDKs;
NSObject<UIApplicationDelegate>* EntryApplicationController;

@implementation SubSDK

+ (void)regSubSDK:(SubSDK*)sub
{
    if (SubSDKs == nil)
    {
        SubSDKs = [[NSMutableArray alloc] init];
    }
    [SubSDKs addObject:sub];
}

+ (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptionsStatic:(NSDictionary*)launchOptions
{
    for (int i = 0; i < SubSDKs.count; ++i)
    {
        SubSDK* subsdk = [SubSDKs objectAtIndex:i];
        [subsdk application:application didFinishLaunchingWithOptions:launchOptions];
    }
    return YES;
}
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    return YES;
}

@end


@interface SDKAppController : UnityAppController
@end
 
IMPL_APP_CONTROLLER_SUBCLASS (SDKAppController)

@implementation SDKAppController
 
- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    EntryApplicationController = self;
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    [SubSDK application:application didFinishLaunchingWithOptionsStatic:launchOptions];
    return YES;
}

@end
