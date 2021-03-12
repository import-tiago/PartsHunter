// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'colors_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$ColorsStore on _ColorsStore, Store {
  final _$primaryColorAtom = Atom(name: '_ColorsStore.primaryColor');

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

  final _$secondaryColorAtom = Atom(name: '_ColorsStore.secondaryColor');

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

  final _$tertiaryColorAtom = Atom(name: '_ColorsStore.tertiaryColor');

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

  @override
  String toString() {
    return '''
primaryColor: ${primaryColor},
secondaryColor: ${secondaryColor},
tertiaryColor: ${tertiaryColor}
    ''';
  }
}
