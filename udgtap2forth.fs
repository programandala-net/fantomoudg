#! /usr/bin/env gforth

\ udgtap2forth.fs

\ By Marcos Cruz (programandala.net)

\ **************************************************************
\ Description

\ This Forth program converts a ZX Spectrum TAP file, containing User
\ Defined Graphics, to hex data ready to be used in a Forth program.

\ **************************************************************
\ Usage

\ s" filename.tap" s" filename.fs" udgtap>forth

\ **************************************************************
\ History

\ 2015-03-23: Start

\ **************************************************************
\ Main

variable scans  \ counter

: udgs>forth  ( ca len -- )
  \ ca len = UDG definitions (8 bytes per graphic)
  scans off hex
  bounds ?do
    i c@ <# bl hold # # #> type
    1 scans +!  scans @ 8 = if  ."  90 UDG!" cr  then
  loop  decimal
  ;

: udgtap>forth ( ca1 len1 ca2 len2 -- )
  \ ca1 len1 = TAP file name
  \ ca2 len2 = output file name
  slurp-file 24 /string udgs>forth
  ;
