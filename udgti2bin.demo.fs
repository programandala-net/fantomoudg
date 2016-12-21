#! /usr/bin/env gforth

\ udgti2bin.demo.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211715

\ ==============================================================
\ Description

\ Demo of the <udgti2bin.fs> converter.

\ This program converts some example TI BASIC UDGs (for TI-99
\ computers) to 8x8 binary grids.

\ ==============================================================
\ Usage

\ ./udgti2bin.demo.fs > output_file.fs

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2013, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2016-12-21: Extract from <udgti2bin.fs>.

\ ==============================================================

include udgti2bin.fs

s" 183C3CFF3C3C3C3C" chardef
s" 472F1F3E7CFA7120" chardef
s" 0808FEFFFFFE0808" chardef
s" 2071FA7C3E1F2F47" chardef
s" 3C3C3C3CFF3C3C18" chardef
s" 048E5F3E7CF8F4E2" chardef
s" 10107FFFFF7F1010" chardef
s" E2F4F87C3E5F8E04" chardef
s" 0000001818000000" chardef
s" 187C7CFFFFFF5E1C" chardef
s" 003C203820202000" chardef
s" 001824202C241800" chardef

bye

