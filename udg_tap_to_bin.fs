#! /usr/bin/env gforth

\ udg_tap_to_bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net/en.program.fantomoudg.html

\ Last modified 201701081726

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

\ Marcos Cruz (programandala.net), 2017.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2017-01-08: Start.

\ ==============================================================
\ Main

only forth definitions  decimal

8 constant scans/udg

variable scan#  \ counter
variable udg#   \ counter

: binary  ( -- )  2 base !  ;

: .scan  ( c -- )
  base @ >r
  s>d binary <# # # # # # # # # #> type
  r> base !  ;

: char-code  ( c1 -- c2 )  bl +  ;

: udg-code  ( c1 -- c2 )  144 +  ;

: ascii?  ( c -- f )  bl 127 within  ;

: .udg-position  ( c -- )  ." UDG position " .  ;

: .udg-code  ( c -- )  ." UDG " . ." in a UDG set"  ;

: .ascii-description  ( c -- )
  ." character " dup . dup ascii?
  if    ." ('" emit ." ') "
  else  drop
  then  ." in a font"  ;

: .description  ( c -- )
  ." \ " dup .udg-position ." = "
         dup udg-code .udg-code ."  = "
         char-code .ascii-description cr ;

: first-scan?  ( -- f )  scan# @ 0=  ;

: last-scan?  ( -- f )  scan# @ scans/udg =  ;

: next-scan  ( -- )  1 scan# +! cr  ;

: next-udg  ( -- )  1 udg# +! scan# off cr  ;

: init  ( -- )  udg# off  scan# off  ;

: udgs>bin  ( ca len -- )
  init  bounds ?do
    first-scan? if  udg# @ .description  then
    i c@ .scan next-scan
    last-scan? if  next-udg  then
  loop  ;
  \ Convert the UDG definitions contained in the memory zone
  \ _ca len_ (8 bytes per UDG) to binary numbers printed to standard
  \ output, with Forth comments.

: behead  ( ca1 len1 -- ca2 len2 )  24 /string 1-  ;
  \ Remove the TAP file header from the TAP file contents _ca1 len1_,
  \ and the checksum byte of the data block, resulting a string _ca2
  \ len2_ that contains only the actual data of the file.

: udgtap>bin ( ca len -- )  slurp-file behead udgs>bin  ;
  \ Convert the UDGs contained in TAP file _ca len_ to binary numbers
  \ printed to standard output, with Forth comments.

1 arg udgtap>bin bye

