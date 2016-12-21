#! /usr/bin/env gforth

\ udgdefb2forth.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211800

\ ==============================================================
\ Description

\ This Forth program converts Z80 assembler 'defb' directives,
\ with binary numbers representing User Defined Graphics, to hex
\ data ready to be used in a Forth program.
\
\ The `udg!` word is used in the output code, which is suitable
\ for Solo Forth.

\ Input format example:

  \ ;; á
  \ defb %00001000
  \ defb %00010000
  \ defb %00111000
  \ defb %00000100
  \ defb %00111100
  \ defb %01000100
  \ defb %00111100
  \ defb %00000000

\ Output:

  \ $08 $10 $38 $04 $3C $44 $3C $00  #128 udg!  \ á

\ ==============================================================
\ Usage

\ See <udgdefb2forth.demo.fs> for a usage example.

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2015, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2015-03-20: First version.
\
\ 2015-03-23: Add '90 UDG!' as default (graphic char and
\ defininig word).
\
\ 2016-12-21: Update file header and source layout. Factor,
\ improve and comment the code. Add an increasing UDG code and
\ make the first one configurable.  Extract the data to their
\ own file, as a demo.

\ ==============================================================
\ Main

variable udg  128 udg !  \ char code of the first UDG

8 constant scans/udg

variable scans  scans off  \ counter

2variable udg-name

: ;;  ( "name" -- )  parse-name save-mem udg-name 2!  ;

: .scan  ( n -- )
  s>d hex <# # # '$' hold #> type space decimal  ;

: get-scan  ( "name" -- n )  parse-name evaluate  ;

: last-scan?  ( -- f )  scans @ scans/udg =  ;

: next-scan  ( -- )  1 scans +!  ;

: next-udg  ( -- )  1 udg +!  scans off  ;

: .udg  ( n -- )  s>d space <# # # # '#' hold #> type space  ;

: .udg-name  ( -- )  ."   \ " udg-name 2@ type cr  ;

: .store-udg  ( -- )  udg @ .udg ." udg!"  ;

: finish-udg  ( -- )  .store-udg .udg-name next-udg  ;

: defb  ( "number" -- )
  get-scan .scan next-scan last-scan? if  finish-udg  then  ;
