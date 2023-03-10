// Copyright (C) 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.Scripting;

namespace GoogleMobileAds
{
  [Preserve]
  public class GoogleMobileAdsClientFactory: IClientFactory
  {
    public IAppStateEventClient BuildAppStateEventClient()
    {
      return GoogleMobileAds.Common.AppStateEventClient.Instance;
    }

    public IAppOpenAdClient BuildAppOpenAdClient()
    {
      if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
      {
        return new GoogleMobileAds.Unity.AppOpenAdClient();
      }
      return new GoogleMobileAds.Common.AppOpenAdAdDummyClient();
    }

    public IBannerClient BuildBannerClient()
    {
      if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
      {
        return new GoogleMobileAds.Unity.BannerClient();
      }
      return new GoogleMobileAds.Common.DummyClient();
    }

    public IInterstitialClient BuildInterstitialClient()
    {
      if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
      {
        return new GoogleMobileAds.Unity.InterstitialClient();
      }
      return new GoogleMobileAds.Common.DummyClient();
     }

    public IRewardedAdClient BuildRewardedAdClient()
    {
      if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
      {
        return new GoogleMobileAds.Unity.RewardedAdClient();
      }
      return new GoogleMobileAds.Common.RewardedAdDummyClient();
    }

    public IRewardedInterstitialAdClient BuildRewardedInterstitialAdClient() {
      if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
      {
        return new GoogleMobileAds.Unity.RewardedInterstitialAdClient();
      }
      return new GoogleMobileAds.Common.RewardedInterstitialAdDummyClient();
    }

    public IMobileAdsClient MobileAdsInstance()
    {
      return new GoogleMobileAds.Common.DummyClient();
    }
  }
}
