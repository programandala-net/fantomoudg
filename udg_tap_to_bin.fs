#! /usr/bin/env gforth

\ udg_tap_to_bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net/en.program.fantomoudg.html

\ Last modified 20221106T1948+0100

\ ==============================================================
\ Description

\ This program converts a ZX Spectrum TAP file, containing User
\ Defined Graphics, to binary numbers printed to standard output,
\ with Forth comments.

\ ==============================================================
\ Usage

\ ./udg_tap_to_bin.fs input_file.tap > output_file.txt

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2017, 2022.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2017-01-08: Start.
\
\ 2022-11-06: Main code moved to <udg_x_to_bin.fs> in order to share
\ it with the new <udg_code_to_bin.fs>.

\ ==============================================================
\ Main

include udg_x_to_bin.fs

only forth definitions  decimal

: behead  ( ca1 len1 -- ca2 len2 )  24 /string 1-  ;
  \ Remove the TAP file header from the TAP file contents _ca1 len1_,
  \ and the checksum byte of the data block, resulting a string _ca2
  \ len2_ that contains only the actual data of the file.

: udgtap>bin ( ca len -- )  slurp-file behead udgs>bin  ;
  \ Convert the UDGs contained in TAP file _ca len_ to binary numbers
  \ printed to standard output, with Forth comments.

1 arg udgtap>bin bye

