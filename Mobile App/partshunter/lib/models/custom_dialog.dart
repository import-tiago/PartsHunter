//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter/services.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:partshunter/screens/keypad_screen.dart';
import 'package:partshunter/screens/register_screen.dart';

//Application
import 'dart:convert';
import 'package:rflutter_alert/rflutter_alert.dart';

import 'package:partshunter/stores/store.dart';

//Screens

class DeleteWidget extends StatefulWidget {
  @override
  _DeleteWidgetState createState() => _DeleteWidgetState();
}

class _DeleteWidgetState extends State<DeleteWidget> {
  var currentSection;
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: Center(
          child: RaisedButton(
            onPressed: () {
              showConfirmationDialog(context);
            },
            child: Text("data"),
          ),
        ),
      ),
    );
  }

  showConfirmationDialog(BuildContext context) {
    showDialog(
      barrierDismissible: false,
      context: context,
      builder: (BuildContext context) {
        return CustomDialog();
      },
    );
  }
}

class CustomDialog extends StatefulWidget {
  @override
  _CustomDialogState createState() => _CustomDialogState();
}

class _CustomDialogState extends State<CustomDialog> {
  List<bool> _isChecked = [false, false];
  bool canUpload = false;
  List<String> _texts = [
    "I have confirm the data is correct",
    "I have agreed to terms and conditions.",
  ];
  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Confirmation'),
      content: Container(
        width: MediaQuery.of(context).size.width,
        height: MediaQuery.of(context).size.height,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Expanded(
              child: ListView(
                  shrinkWrap: true,
                  padding: EdgeInsets.all(8.0),
                  children: [
                    ListView.builder(
                      shrinkWrap: true,
                      itemCount: _texts.length,
                      itemBuilder: (_, index) {
                        return CheckboxListTile(
                          title: Text(_texts[index]),
                          value: _isChecked[index],
                          onChanged: (val) {
                            setState(() {
                              _isChecked[index] = val;
                              canUpload = true;
                              for (var item in _isChecked) {
                                if (item == false) {
                                  canUpload = false;
                                }
                              }
                            });
                          },
                        );
                      },
                    ),
                  ]),
            ),
          ],
        ),
      ),
      actions: <Widget>[
        SizedBox(
            width: 300,
            child: RaisedButton(
              color: Colors.blue,
              onPressed: canUpload
                  ? () {
                      print("upload");
                    }
                  : null,
              child: Text('Upload'),
            ))
      ],
    );
  }
}