//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

//Application
import 'package:provider/provider.dart';
import 'package:splashscreen/splashscreen.dart';

//Screens
import 'package:partshunter/screens/search_screen.dart';

//Stores


void main() {
  runApp(MyApp());
}

// ignore: must_be_immutable
class MyApp extends StatelessWidget {
  

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
        providers: [
          Provider<SearchScreen>(create: (_) => SearchScreen()),
        ],
        child: MaterialApp(
            debugShowCheckedModeBanner: false,
            home: MaterialApp(
              debugShowCheckedModeBanner: false,
              title: 'PartsHunter',
              theme: ThemeData(
                primaryColor: Color.fromRGBO(41, 55, 109, 1.0),
                accentColor: Color.fromRGBO(155, 252, 255, 1.0),
                visualDensity: VisualDensity.adaptivePlatformDensity,
              ),
              home: _introScreen(),
            )));
  }

  Widget _introScreen() {
    return Stack(
      alignment: Alignment.center,
      children: [
        SplashScreen(
          seconds: 1,
          gradientBackground: LinearGradient(
            begin: Alignment.topRight,
            end: Alignment.bottomLeft,
            colors: [Colors.white, Colors.lightBlueAccent[90]],
          ),
          navigateAfterSeconds: SearchScreen(),
          loaderColor: Colors.transparent,
        ),
        Container(
          width: 200,
          height: 200,
          decoration: BoxDecoration(
            image: DecorationImage(
              image: AssetImage("lib/assets/logo.png"),
              fit: BoxFit.contain,
            ),
          ),
        ),
      ],
    );
  }
}
