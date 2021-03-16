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

  final _$JSON_ObjAtom = Atom(name: '_PartsDatabaseStore.JSON_Obj');

  @override
  List<Map<dynamic, dynamic>> get JSON_Obj {
    _$JSON_ObjAtom.reportRead();
    return super.JSON_Obj;
  }

  @override
  set JSON_Obj(List<Map<dynamic, dynamic>> value) {
    _$JSON_ObjAtom.reportWrite(value, super.JSON_Obj, () {
      super.JSON_Obj = value;
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

  final _$listsAtom = Atom(name: '_PartsDatabaseStore.lists');

  @override
  List<Map<dynamic, dynamic>> get lists {
    _$listsAtom.reportRead();
    return super.lists;
  }

  @override
  set lists(List<Map<dynamic, dynamic>> value) {
    _$listsAtom.reportWrite(value, super.lists, () {
      super.lists = value;
    });
  }

  final _$DataTable_LengthAtom =
      Atom(name: '_PartsDatabaseStore.DataTable_Length');

  @override
  int get DataTable_Length {
    _$DataTable_LengthAtom.reportRead();
    return super.DataTable_Length;
  }

  @override
  set DataTable_Length(int value) {
    _$DataTable_LengthAtom.reportWrite(value, super.DataTable_Length, () {
      super.DataTable_Length = value;
    });
  }

  final _$Get_Firebase_and_Convert_to_JSONAsyncAction =
      AsyncAction('_PartsDatabaseStore.Get_Firebase_and_Convert_to_JSON');

  @override
  Future Get_Firebase_and_Convert_to_JSON() {
    return _$Get_Firebase_and_Convert_to_JSONAsyncAction
        .run(() => super.Get_Firebase_and_Convert_to_JSON());
  }

  final _$Snapshot_to_JSONAsyncAction =
      AsyncAction('_PartsDatabaseStore.Snapshot_to_JSON');

  @override
  Future<void> Snapshot_to_JSON(
      {AsyncSnapshot<DataSnapshot> snapshot, DataSnapshot snap}) {
    return _$Snapshot_to_JSONAsyncAction
        .run(() => super.Snapshot_to_JSON(snapshot: snapshot, snap: snap));
  }

  final _$Fill_DataTrable_from_Selected_CategoryAsyncAction =
      AsyncAction('_PartsDatabaseStore.Fill_DataTrable_from_Selected_Category');

  @override
  Future Fill_DataTrable_from_Selected_Category(String selected_category) {
    return _$Fill_DataTrable_from_Selected_CategoryAsyncAction.run(
        () => super.Fill_DataTrable_from_Selected_Category(selected_category));
  }

  final _$_PartsDatabaseStoreActionController =
      ActionController(name: '_PartsDatabaseStore');

  @override
  void Build_DropDown() {
    final _$actionInfo = _$_PartsDatabaseStoreActionController.startAction(
        name: '_PartsDatabaseStore.Build_DropDown');
    try {
      return super.Build_DropDown();
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
JSON_Obj: ${JSON_Obj},
dropDownMenuItems: ${dropDownMenuItems},
lists: ${lists},
DataTable_Length: ${DataTable_Length}
    ''';
  }
}
