using Paint.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint.Model.Models;
using Paint.Data.Interface;

namespace Paint.Service
{
   public class PaintService : IPaintService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IDefectRepository _defectRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMixRoomRepository _mixRoomRepository;
        private readonly IPartLogRepository _partLogRepository;
        private readonly IPartRepository _partRepository;
        private readonly ISolventRepository _solventRepository;

        public PaintService(IColorRepository colorRepository,
                            IDefectRepository defectRepository,
                            IManufacturerRepository manufacturerRepository,
                            IMixRoomRepository mixRoomRepository,
                            IPartLogRepository partLogRepository,
                            IPartRepository partRepository,
                            ISolventRepository solventRepository
            )
        {
            _colorRepository = colorRepository;
            _defectRepository = defectRepository;
            _manufacturerRepository = manufacturerRepository;
            _mixRoomRepository = mixRoomRepository;
            _partLogRepository = partLogRepository;
            _partRepository = partRepository;
            _solventRepository = solventRepository;
        }

        public IEnumerable<Color> GetAllColors()
        {
            return _colorRepository.GetAll();
        }

        public IEnumerable<Defect> GetAllDefects()
        {
            return _defectRepository.GetAll();
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return _manufacturerRepository.GetAll();
        }

      
        public IEnumerable<Solvent> GetAllSolvents()
        {
            return _solventRepository.GetAll();
        }

        public IEnumerable<PartLog> GetByBarcode(long barcodeId)
        {
            return _partLogRepository.GetByBarcode(barcodeId);
        }

        public IEnumerable<Part> GetAllParts()
        {
            return _partRepository.GetAll();
        }

        public IEnumerable<Part> GetPartsByManufacturerId(int manufacturerId)
        {
            return _partRepository.GetAllByManufacturerId(manufacturerId);

        }

        public void SaveMixRoom(ref MixRoom model)
        {
            _mixRoomRepository.Save(ref model);
        }

        public void SavePartLog(ref PartLog model)
        {
            _partLogRepository.Save(ref model);
        }
    }
}
