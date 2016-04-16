using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api; // 구글 애드몹 API 네임 스페이스



public class AdMob : MonoBehaviour
{
    static BannerView bannerView = null; // 배너 출력
    public bool bannerOn;
    void Start()
    {
        if (bannerView == null)
        {
            // BannerView(애드몹 사이트에 등록된 아이디, 크기, 위치) / AdSize.SmartBanner : 화면 해상도에 맞게 늘임, AdPosition.Bottom : 화면 바닥에 붙음
            bannerView = new BannerView("ca-app-pub-5905358959749177/1254674846", AdSize.SmartBanner, AdPosition.Bottom);

            //서버 광고 요청
            AdRequest.Builder builder = new AdRequest.Builder();
            // 테스트 디바이스 등록 ( 테스트 디바이스에서는 결제가 안된다 )
            // request 요청 정보를 담는다.
            AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("D8A7E633E004B1E5").Build();  //3D005AAC7FC7C0C5 : 디바이스 아이디

            //AdRequest request = builder.Build();// 실제 빌드

            bannerView.LoadAd(request); //배너 광고 요청
        }
        if (bannerOn)
            bannerView.Show();
        else
            bannerView.Hide();
    }

    void Update()
    {

    }




}
