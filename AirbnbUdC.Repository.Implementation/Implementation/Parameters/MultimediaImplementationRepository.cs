﻿using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.Contracts.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class MultimediaTypeImplementationRepository : IMultimediaTypeRepository
    {
        /// <summary>
        /// Método para crear un registro de MultimediaType en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no. O una excepción</returns>
        public MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.MultimediaType.Any(x => x.MultimediaTypeName.Equals(record.MultimediaTypeName)))
                    {
                        MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();
                        MultimediaType dbRecord = mapper.MapperT2toT1(record);
                        db.MultimediaType.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return record;
        }

        /// <summary>
        /// Método para eliminar un registro de MultimediaType en la base de datos
        /// </summary>
        /// <param name="recordId">Id del registro a eliminar</param>
        /// <returns>1 cuando se elimina, 0 cuando no existe, o excepción</returns>
        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    MultimediaType record = db.MultimediaType.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.MultimediaType.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                // porque se tiene como llave foránea en otra tabla
                throw e;
            }
        }

        /// <summary>
        /// Método para obtener todos los registros de MultimediaType en la base de datos
        /// </summary>
        /// <returns>Listado de registros con países</returns>
        public IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.MultimediaType
                    where c.MultimediaTypeName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.MultimediaType.Where(x => x.MultimediaTypeName.Contains(filter));

                MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<MultimediaTypeDbModel> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public MultimediaTypeDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.MultimediaType.Find(recordId);

                MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        /// <summary>
        /// Método para actualizar un registro de MultimediaType en la base de datos
        /// </summary>
        /// <param name="record">Registro con nuevos datos</param>
        /// <returns>1 cuando se actualiza, 0 cuando no se actualiza o una excepciòn</returns>
        public int UpdateRecord(MultimediaTypeDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();
                    MultimediaType dbRecord = mapper.MapperT2toT1(record);
                    db.MultimediaType.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }
    }
}
