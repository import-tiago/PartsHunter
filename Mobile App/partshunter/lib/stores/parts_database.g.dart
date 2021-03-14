// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'parts_database.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$PartsDatabaseStore on _PartsDatabaseStore, Store {
  final _$primaryColorAtom = Atom(name: '_PartsDatabaseStore.primaryColor');

  @override
  Color get primaryColor {
    _$primaryColorAtom.reportRead();
    return super.primaryColor;
  }

  @override
  set primaryColor(Color value) {
    _$primaryColorAtom.reportWrite(value, super.primaryColor, () {
      super.primaryColor = value;
    });
  }

  final _$secondaryColorAtom = Atom(name: '_PartsDatabaseStore.secondaryColor');

  @override
  Color get secondaryColor {
    _$secondaryColorAtom.reportRead();
    return super.secondaryColor;
  }

  @override
  set secondaryColor(Color value) {
    _$secondaryColorAtom.reportWrite(value, super.secondaryColor, () {
      super.secondaryColor = value;
    });
  }

  final _$tertiaryColorAtom = Atom(name: '_PartsDatabaseStore.tertiaryColor');

  @override
  Color get tertiaryColor {
    _$tertiaryColorAtom.reportRead();
    return super.tertiaryColor;
  }

  @override
  set tertiaryColor(Color value) {
    _$tertiaryColorAtom.reportWrite(value, super.tertiaryColor, () {
      super.tertiaryColor = value;
    });
  }

  final _$jsonAtom = Atom(name: '_PartsDatabaseStore.json');

  @override
  List<Map<dynamic, dynamic>> get json {
    _$jsonAtom.reportRead();
    return super.json;
  }

  @override
  set json(List<Map<dynamic, dynamic>> value) {
    _$jsonAtom.reportWrite(value, super.json, () {
      super.json = value;
    });
  }

  final _$dropDownMenuItemsAtom =
      Atom(name: '_PartsDatabaseStore.dropDownMenuItems');

  @override
  List<DropdownMenuItem<String>> get dropDownMenuItems {
    _$dropDownMenuItemsAtom.reportRead();
    return super.dropDownMenuItems;
  }

  @override
  set dropDownMenuItems(List<DropdownMenuItem<String>> value) {
    _$dropDownMenuItemsAtom.reportWrite(value, super.dropDownMenuItems, () {
      super.dropDownMenuItems = value;
    });
  }

  final _$_PartsDatabaseStoreActionController =
      ActionController(name: '_PartsDatabaseStore');

  @override
  void buildAndGetDropDownMenuItems() {
    final _$actionInfo = _$_PartsDatabaseStoreActionController.startAction(
        name: '_PartsDatabaseStore.buildAndGetDropDownMenuItems');
    try {
      return super.buildAndGetDropDownMenuItems();
    } finally {
      _$_PartsDatabaseStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
primaryColor: ${primaryColor},
secondaryColor: ${secondaryColor},
tertiaryColor: ${tertiaryColor},
json: ${json},
dropDownMenuItems: ${dropDownMenuItems}
    ''';
  }
}
