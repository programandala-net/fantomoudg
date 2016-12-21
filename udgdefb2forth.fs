#! /usr/bin/env gforth

\ udgdefb2forth.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211618

\ ==============================================================
\ Description

\ This Forth program converts Z80 assembler 'defb' directives,
\ with binary numbers representing User Defined Graphics, to hex
\ data ready to be used in a Forth program.

\ ==============================================================
\ Usage

\ ./udgdefb2forth.fs > output_file.fs

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
\ make the first one configurable.

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

: finish-udg  ( -- )
  udg @ .udg ." udg!  \ " udg-name 2@ type cr  next-udg  ;

: defb  ( "number" -- )
  get-scan .scan next-scan last-scan? if  finish-udg  then  ;

\ ==============================================================
\ Usage example

1 [if]

  \ include udgdefb2forth.fs

  ;; á
  defb %00001000
  defb %00010000
  defb %00111000
  defb %00000100
  defb %00111100
  defb %01000100
  defb %00111100
  defb %00000000
  ;; Á
  defb %00000100
  defb %00001000
  defb %00111100
  defb %01000010
  defb %01111110
  defb %01000010
  defb %01000010
  defb %00000000
  ;; é
  defb %00001000
  defb %00010000
  defb %00111000
  defb %01000100
  defb %01111000
  defb %01000000
  defb %00111100
  defb %00000000
  ;; É
  defb %00000100
  defb %00001000
  defb %01111110
  defb %01000000
  defb %01111100
  defb %01000000
  defb %01111110
  defb %00000000
  ;; í
  defb %00001000
  defb %00010000
  defb %00000000
  defb %00110000
  defb %00010000
  defb %00010000
  defb %00111000
  defb %00000000
  ;; Í
  defb %00000100
  defb %00001000
  defb %00111110
  defb %00001000
  defb %00001000
  defb %00001000
  defb %00111110
  defb %00000000
  ;; ó
  defb %00001000
  defb %00010000
  defb %00111000
  defb %01000100
  defb %01000100
  defb %01000100
  defb %00111000
  defb %00000000
  ;; Ó
  defb %00001000
  defb %00010000
  defb %00111100
  defb %01000010
  defb %01000010
  defb %01000010
  defb %00111100
  defb %00000000
  ;; ú
  defb %00001000
  defb %00010000
  defb %01000100
  defb %01000100
  defb %01000100
  defb %01000100
  defb %00111000
  defb %00000000
  ;; Ú
  defb %00000100
  defb %01001010
  defb %01000010
  defb %01000010
  defb %01000010
  defb %01000010
  defb %00111100
  defb %00000000
  ;; ñ
  defb %00000000
  defb %01111000
  defb %00000000
  defb %01111000
  defb %01000100
  defb %01000100
  defb %01000100
  defb %00000000
  ;; Ñ
  defb %00111100
  defb %00000000
  defb %01100010
  defb %01010010
  defb %01001010
  defb %01000110
  defb %01000010
  defb %00000000
  ;; ü
  defb %01000100
  defb %00000000
  defb %01000100
  defb %01000100
  defb %01000100
  defb %01000100
  defb %00111000
  defb %00000000
  ;; Ü
  defb %01000010
  defb %00000000
  defb %01000010
  defb %01000010
  defb %01000010
  defb %01000010
  defb %00111100
  defb %00000000
  ;; ¿
  defb %00000000
  defb %00010000
  defb %00000000
  defb %00010000
  defb %00100000
  defb %01000010
  defb %00111100
  defb %00000000
  ;; ¡
  defb %00000000
  defb %00001000
  defb %00000000
  defb %00001000
  defb %00001000
  defb %00001000
  defb %00001000
  defb %00000000
  ;; º
  defb %00011000
  defb %00100100
  defb %00011000
  defb %00000000
  defb %00111100
  defb %00000000
  defb %00000000
  defb %00000000
  ;; «
  defb %00000000
  defb %00000000
  defb %00010010
  defb %00100100
  defb %01001000
  defb %00100100
  defb %00010010
  defb %00000000
  ;; »
  defb %00000000
  defb %00000000
  defb %01001000
  defb %00100100
  defb %00010010
  defb %00100100
  defb %01001000
  defb %00000000

  bye

[then]
