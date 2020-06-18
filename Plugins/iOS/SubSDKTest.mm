//
//  SubSDKTest.m
//  Unity-iPhone
//
//  Created by admin on 2020/6/18.
//

#import <Foundation/Foundation.h>
#import "SubSDK.h"

@interface SubSDKTest : SubSDK
@end

REG_SUBSDK(SubSDKTest)

@implementation SubSDKTest

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    ::printf("this is from SubSDKTest");
    ::printf("%p", EntryApplicationController);
    return YES;
}

@end
